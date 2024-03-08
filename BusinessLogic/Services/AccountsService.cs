using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.Entities;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;
using BusinessLogic.Resources;
using BusinessLogic.Specifications;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NETCore.MailKit.Core;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
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
		private async Task<string> CreateRefreshToken(string userId)
		{
			var refeshToken = jwtService.CreateRefreshToken();

			var refreshTokenEntity = new RefreshToken
			{
				Token = refeshToken,
				UserId = userId,
				CreationDate = DateTime.UtcNow // Now vs UtcNow
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
								IValidator<EditUserModel> userModelValidator)
		{
			this.userManager = userManager;
			this.mapper = mapper;
			this.registerValidator = registerValidator;
			this.resetModelValidator = resetModelValidator;
			this.emailService = emailService;
			this.jwtService = jwtService;
			this.tokenRepository = tokenRepository;
			this.userModelValidator = userModelValidator;
			
		}

		public async Task<RefreshToken> GetRefreshToken(string rToken)
		{
			var token = await tokenRepository.GetItemBySpec(new RefreshTokenSpecs.GetTokenByValue(rToken));
			if(token == null || token.CreationDate < jwtService.GetLastValidTokenDate())
				   throw new HttpException(Errors.InvalidToken, HttpStatusCode.BadRequest);
			return token;
		}

		public async Task Register(RegisterUserModel model)
		{
			registerValidator.ValidateAndThrow(model);

			if (await userManager.FindByEmailAsync(model.Email) != null)
				throw new HttpException(Errors.EmailExists, HttpStatusCode.BadRequest);

			var user = mapper.Map<User>(model);

			var result = await userManager.CreateAsync(user, model.Password);
			await userManager.AddToRoleAsync(user, model.Role);
			if (!result.Succeeded)
				throw new HttpException(string.Join(" ", result.Errors.Select(x => x.Description)), HttpStatusCode.BadRequest);
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


		public async Task Logout(AuthResponse tokens)
		{
			var rToken = GetRefreshToken(tokens.RefreshToken);
			await tokenRepository.DeleteAsync(rToken);
			await tokenRepository.SaveAsync();
		}
		
		public async Task<ResetPasswordResponse> ResetPasswordRequest(string email)
		{
			ResetPasswordResponse rModel = new(); 
			var user = await userManager.FindByEmailAsync(email);
			if (user != null)
			{
				rModel.Token = await userManager.GeneratePasswordResetTokenAsync(user);
				rModel.UserId = user.Id;
				await emailService.SendAsync(email,"Reset password",  $"\"Для сброса пароля пройдите по ссылке: <a href='#'>Reset password</a>\"",true);
			}
			return rModel;
		}

		public async Task ResetPassword(ResetPasswordModel model)
		{
			resetModelValidator.ValidateAndThrow(model);
			var user = await userManager.FindByIdAsync(model.UserId) 
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
	}
}
