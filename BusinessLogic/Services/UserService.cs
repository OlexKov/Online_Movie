using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Resources;
using BusinessLogic.Specifications;
using Microsoft.AspNetCore.Identity;

namespace BusinessLogic.Services
{
	internal class UserService : IUserService
	{
		private readonly UserManager<User> userManager;
		private readonly IRepository<Movie> movieRepository;
		private readonly IRepository<UserMovie> userMovieRepository;
		private readonly IRepository<Premium> premRepository;
		private readonly IMapper mapper;
		private readonly IRepository<User> userRepository;

		private async Task<User> getUser(string name) => await userManager.FindByNameAsync(name)
				 ?? throw new HttpException(Errors.UserNotFound, System.Net.HttpStatusCode.BadRequest);

		private void clearPremium(User user)
		{
			user.PremiumId = null;
			user.Premium = null;
		}
		

		public UserService(UserManager<User> userManager, IRepository<Movie> movieRepository, 
			               IRepository<UserMovie> userMovieRepository,IRepository<Premium> premRepository,
						   IMapper mapper, IRepository<User> userRepository)
		{
			this.userManager = userManager;
			this.movieRepository = movieRepository;
			this.userMovieRepository = userMovieRepository;
			this.premRepository = premRepository;
			this.mapper = mapper;
			this.userRepository = userRepository;
		}
         
		public async Task AddRemoveFavourite(string userName, int movieId)
		{
			if(await movieRepository.GetByIDAsync(movieId) == null)
				 throw new HttpException(Errors.NotFoundById,System.Net.HttpStatusCode.BadRequest);
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

		}

		public async Task<IEnumerable<MovieDto>> GetFavourits(string userName) => await GetFavourits(await getUser(userName));
		
		public async Task<IEnumerable<MovieDto>> GetFavourits(User user)
		{
			var movies = (await userMovieRepository.GetListBySpec(new UserMovieSpecs.GetByUserId(user.Id)))
											                       .Select(x => x.Movie);
			var moviesDtos = mapper.Map<IEnumerable<MovieDto>>(movies);
			return moviesDtos;
		}

		public async Task<PremiumDto?> GetPremium(string userName)
		{
			PremiumDto? premium = null;
			var user = await userRepository.GetItemBySpec(new UserSpecs.GetByNameInc(userName))
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
				
		public async Task SetPremium(string userName, int premiumId , int days)
		{
			var user = await getUser(userName);
			if(await premRepository.GetByIDAsync(premiumId) == null)
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
