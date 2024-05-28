using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;
using BusinessLogic.Interfaces;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;
using BusinessLogic.Resources;
using BusinessLogic.Specifications;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NETCore.MailKit.Core;
using System.Data;
using System.Net;



namespace BusinessLogic.Services
{
	internal class AccountsService : IAccountsService
	{
		private readonly UserManager<User> userManager;
		private readonly IMapper mapper;
		private readonly IValidator<RegisterUserModel> registerValidator;
		private readonly IValidator<ResetPasswordModel> resetModelValidator;
		private readonly IEmailService emailService;
		private readonly IJwtService jwtService;
		private readonly IRepository<RefreshToken> tokenRepository;
		private readonly IValidator<EditUserModel> userModelValidator;
		private readonly IRepository<UserMovie> userMovieRepository;
		private readonly IRepository<Premium> premRepository;
		private readonly IRepository<User> userRepository;
		private readonly IRepository<Movie> movieRepository;

		private async Task<User> getUser(string name) => await userManager.FindByNameAsync(name)
				 ?? throw new HttpException(Errors.UserNotFound, System.Net.HttpStatusCode.BadRequest);

		private void clearPremium(User user)
		{
			user.PremiumId = null;
			user.Premium = null;
		}
		private async Task<string> CreateRefreshToken(string userId)
		{
			var refeshToken = jwtService.CreateRefreshToken();

			var refreshTokenEntity = new RefreshToken
			{
				Token = refeshToken,
				UserId = userId,
				ExpirationDate = DateTime.UtcNow.AddDays(jwtService.GetRefreshTokenLiveTime()) // Now vs UtcNow
			};

			await tokenRepository.InsertAsync(refreshTokenEntity);
			await tokenRepository.SaveAsync();

			return refeshToken;
		}

		public AccountsService(UserManager<User> userManager,
								IMapper mapper,
								IValidator<RegisterUserModel> registerValidator,
								IValidator<ResetPasswordModel> resetModelValidator,
								IEmailService emailService, IJwtService jwtService,
								IRepository<RefreshToken> tokenRepository,
								IValidator<EditUserModel> userModelValidator,
								IRepository<UserMovie> userMovieRepository, 
								IRepository<Premium> premRepository,
						        IRepository<User> userRepository,
								IRepository<Movie> movieRepository)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.registerValidator = registerValidator;
			this.resetModelValidator = resetModelValidator;
			this.emailService = emailService;
			this.jwtService = jwtService;
			this.tokenRepository = tokenRepository;
			this.userModelValidator = userModelValidator;
			this.userMovieRepository = userMovieRepository;
			this.premRepository = premRepository;
			this.userRepository = userRepository;
			this.movieRepository = movieRepository;
		}

		public async Task<RefreshToken> GetRefreshToken(string rToken)
		{
			
			var token = await tokenRepository.GetItemBySpec(new RefreshTokenSpecs.GetTokenByValue(rToken));
			if (token == null || token.ExpirationDate < DateTime.UtcNow)
				   throw new HttpException(Errors.InvalidToken, HttpStatusCode.Unauthorized);
			return token;
		}

		public async Task Register(RegisterUserModel model)
		{
			registerValidator.ValidateAndThrow(model);

			if (await userManager.FindByEmailAsync(model.Email) != null)
				throw new HttpException(Errors.EmailExists, HttpStatusCode.BadRequest);

			var user = mapper.Map<User>(model);

			var result = await userManager.CreateAsync(user, model.Password);
			if (!result.Succeeded)
				throw new HttpException(string.Join(" ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
			await userManager.AddToRoleAsync(user, model.Role);
			
		}

		public async Task<AuthResponse> Login(AuthRequest model)
		{
			var user = await userManager.FindByEmailAsync(model.Email);

			if (user == null || !await userManager.CheckPasswordAsync(user, model.Password))
				throw new HttpException(Errors.InvalidRegData, HttpStatusCode.BadRequest);

			return new()
			{
				AccessToken = jwtService.CreateToken(await jwtService.GetClaimsAsync(user)),
				RefreshToken =  await CreateRefreshToken(user.Id)
			};
		}


		public async Task Logout(string token)
		{
			var rToken = await GetRefreshToken(token);
			await tokenRepository.DeleteAsync(rToken.Id);
			await tokenRepository.SaveAsync();
		}

		public async Task ResetPasswordRequest(FogotPasswordModel fogotModel)
		{
			var user = await userManager.FindByEmailAsync(fogotModel.Email);
			if (user != null)
			{
				var token = await userManager.GeneratePasswordResetTokenAsync(user);
				await emailService.SendAsync(fogotModel.Email, "Reset password", $"\"Для зміни пароля перейдіть за посиланням: <a href='{fogotModel.ResetPasswordPage}?token={token}&email={user.Email}'>Змінити пароль</a>\"", true);
			}
		}

		public async Task<string> GetResetToken(string email) 
		{
			var user = await userManager.FindByEmailAsync(email)
			         ?? throw new HttpException(Errors.UserNotFound, HttpStatusCode.BadRequest);
			return await userManager.GeneratePasswordResetTokenAsync(user);
		}

		public async Task ResetPassword(ResetPasswordModel model)
		{
			resetModelValidator.ValidateAndThrow(model);
			var user = await userManager.FindByEmailAsync(model.UserEmail) 
				?? throw new HttpException(Errors.NotFoundById,HttpStatusCode.NotFound);
			var result = await userManager.ResetPasswordAsync(user,model.Token,model.Password);
			if (!result.Succeeded)
				throw new HttpException(string.Join(" ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
		}

		public async Task Delete(User user)
		{
			if(user == null) throw new HttpException(Errors.NullReference, HttpStatusCode.BadRequest);
			var result = await userManager.DeleteAsync(user);
			if(!result.Succeeded) throw new HttpException(string.Join(" ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
		}

		public async Task Delete(string email)
		{
			var user = await userManager.FindByEmailAsync(email) 
				?? throw new HttpException(Errors.NotFoundById, HttpStatusCode.BadRequest);
			await Delete(user);
		}

		public async Task<AuthResponse> RefreshTokens(AuthResponse tokens)
		{
			var refrestToken = await GetRefreshToken(tokens.RefreshToken);
			var claims = jwtService.GetClaimsFromExpiredToken(tokens.AccessToken);
			var newAccessToken = jwtService.CreateToken(claims);
			var newRefreshToken = jwtService.CreateRefreshToken();
			refrestToken.Token = newRefreshToken;
			tokenRepository.Update(refrestToken);
			await tokenRepository.SaveAsync();
			var userTokens = new AuthResponse()
			{
				AccessToken = newAccessToken,
				RefreshToken = newRefreshToken
			};
			return userTokens;
		}

		public async Task Edit(EditUserModel model)
		{
			userModelValidator.ValidateAndThrow(model);

			var user = await userManager.FindByIdAsync(model.Id) 
				 ?? throw new HttpException(Errors.EmailExists, HttpStatusCode.BadRequest);
			user.Name = model.Name;
			user.Surname = model.Surname;
			user.Birthdate = model.Birthdate;
			var result = await userManager.UpdateAsync(user);
			if (!result.Succeeded)
				throw new HttpException(string.Join(" ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
		}

		public async Task RemoveExpiredRefreshTokens()
		{
			var lastDate = jwtService.GetLastValidTokenDate();
			var expiredTokens = await tokenRepository.GetListBySpec(new RefreshTokenSpecs.ByDate(lastDate));

			foreach (var i in expiredTokens)
			{
				tokenRepository.Delete(i);
			}
			await tokenRepository.SaveAsync();
		}

		public async Task<bool> IsMovieFauvorite(int movieId, string userId)
		{
			if (movieId < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			if (String.IsNullOrWhiteSpace(userId)) throw new HttpException(Errors.UserNotFound, HttpStatusCode.BadRequest);
			return (await userMovieRepository.GetItemBySpec(new UserMovieSpecs.GetUserMovieByMovieId(userId,movieId))) != null;
		}

		public async Task<bool> AddRemoveFavourite(string userName, int movieId)
		{
			if (await movieRepository.GetByIDAsync(movieId) == null)
				throw new HttpException(Errors.NotFoundById,HttpStatusCode.BadRequest);
			var user = await getUser(userName);
			var favourite = await userMovieRepository.GetItemBySpec(new UserMovieSpecs.GetUserMovieByMovieId(user.Id, movieId));
			if (favourite == null)
			{
				user.UserMovies.Add(new() { MovieId = movieId, UserId = user.Id });
				await userManager.UpdateAsync(user);
			}
			else
			{
				userMovieRepository.Delete(favourite);
				await userMovieRepository.SaveAsync();
			}
			return favourite == null;
		}

		public async Task<IEnumerable<MovieDto>> GetFavouritesAsync(string userName) => await GetFavouritesAsync(await getUser(userName));

		public async Task<IEnumerable<MovieDto>> GetFavouritesAsync(User user)
		{
			var movies = (await userMovieRepository.GetListBySpec(new UserMovieSpecs.GetByUserId(user.Id)))
																   .Select(x => x.Movie);
			var moviesDtos = mapper.Map<IEnumerable<MovieDto>>(movies);
			return moviesDtos;
		}

		public async Task<PremiumDto?> GetPremium(string email)
		{
			PremiumDto? premium = null;
			var user = await userRepository.GetItemBySpec(new UserSpecs.GetByEmailInc(email))
				 ?? throw new HttpException(Errors.UserNotFound, System.Net.HttpStatusCode.BadRequest);
			if (user.Premium != null)
			{
				if (user.PremiumDate > DateTime.UtcNow)
					premium = mapper.Map<PremiumDto>(user.Premium);
				else
				{
					clearPremium(user);
					await userManager.UpdateAsync(user);
				}
			}
			return premium;
		}

		public async Task SetPremium(string userName, int premiumId, int days)
		{
			var user = await getUser(userName);
			if (await premRepository.GetByIDAsync(premiumId) == null)
				throw new HttpException(Errors.NotFoundById, System.Net.HttpStatusCode.BadRequest);
			if (days <= 0)
				clearPremium(user);
			else
			{
				user.PremiumId = premiumId;
				user.PremiumDate = DateTime.UtcNow.AddDays(days);
			}
			await userManager.UpdateAsync(user);
		}
	}
}
