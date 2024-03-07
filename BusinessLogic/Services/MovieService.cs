using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using BusinessLogic.Resources;
using BusinessLogic.Specifications;
using FluentValidation;
using System.Net;

namespace BusinessLogic.Services
{
	internal class MovieService : IMovieService
	{
		private readonly IRepository<Movie> movies;
		private readonly IRepository<Feedback> feedbacks;
		private readonly IRepository<StafMovie> stafMovies;
		private readonly IRepository<MovieGenre> movieGenres;
		private readonly IMapper mapper;
		private readonly IImageService imageService;
		private readonly IValidator<MovieModel> validator;


		private async Task deleteMovieDependencies(int id)
		{
			var stafs = await stafMovies.GetListBySpec(new StafMovieSpecs.GetByMovieId(id));
			var genres = await movieGenres.GetListBySpec(new MovieGenreSpecs.GetByMovieId(id));

			foreach (var item in stafs)
				stafMovies.Delete(item);
			foreach (var item in genres)
				movieGenres.Delete(item);
		}

		private async Task<Movie> setData(MovieModel movieModel, bool update)
		{
			validator.ValidateAndThrow(movieModel);
			var movie = mapper.Map<Movie>(movieModel);
			if (update)
				await deleteMovieDependencies(movie.Id);

			foreach (var id in movieModel.Stafs)
				movie.StafMovies.Add(new () { MovieId = movie.Id, StafId = id });
			foreach (var id in movieModel.Genres)
				movie.MovieGenres.Add(new() { MovieId = movie.Id, GenreId = id });
			foreach (var item in movieModel.Screens)
				movie.ScreenShots.Add(new() { MovieId = movie.Id, Name = await imageService.SaveImageAsync(item) });
			
			if (movieModel.PosterFile != null)
			{
				movie.Poster = await imageService.SaveImageAsync(movieModel.PosterFile);
				if (update && movieModel.Poster != null && movieModel.Poster != "nophoto.jpeg")
					imageService.DeleteImageByName(movieModel.Poster);
			}
			return movie;
		}


		public MovieService(IRepository<Movie> movies, IRepository<Feedback> feedbacks,
			                IRepository<StafMovie> stafMovie,
							IRepository<MovieGenre> movieGenre, IMapper mapper,
							IImageService imageService, IValidator<MovieModel> validator)
		{
			this.movies = movies;
			this.feedbacks = feedbacks;
			this.stafMovies = stafMovie;
			this.movieGenres = movieGenre;
			this.mapper = mapper;
			this.imageService = imageService;
			this.validator = validator;
		}
	

		public async Task DeleteAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			var movie = await movies.GetItemBySpec(new MovieSpecs.GetByIdIncCollections(id)) 
				                          ?? throw new HttpException(Errors.NotFoundById, HttpStatusCode.NotFound);
			movies.Delete(movie);
			await movies.SaveAsync();
			foreach (var item in movie.ScreenShots)
				imageService.DeleteImageByName(item.Name);
			imageService.DeleteImageByName(movie.Poster ?? "");
		}

		public async Task<IEnumerable<MovieDto>> GetAllAsync() => mapper.Map<IEnumerable<MovieDto>>(await movies.GetListBySpec(new MovieSpecs.GetAll()));
		

		public async Task<MovieDto> GetByIdAsync(int id)
		{
			return id < 0
				? throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest)
				: mapper.Map<MovieDto>(await movies.GetItemBySpec(new MovieSpecs.GetByIdInc(id)) 
				?? throw new HttpException(Errors.NotFoundById, HttpStatusCode.NotFound));
		}

		public async Task<IEnumerable<FeedbackDto>> GetFeedbacksAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			return mapper.Map<IEnumerable<FeedbackDto>>(await feedbacks.GetListBySpec(new FeedbacsSpecs.GetByMovieId(id)));
		}

		public async Task<IEnumerable<StafDto>> GetStafAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			return mapper.Map<IEnumerable<StafDto>>(await stafMovies.GetListBySpec(new StafMovieSpecs.GetByMovieId(id)));
		}

		//public async Task<IEnumerable<MovieDto>> GetTopAsync(int count)
		//{
		//	var ratings = await feedbacks.GetAsync(selector:x=>x);
		//	var res = ratings.GroupBy(x => x.MovieId)
		//		                                               .Select(x=>  new {Id = x.Key,rating = x.Average(z=>z.Rating)})
		//												       .OrderByDescending(x=>x.rating).Take(count);
		//	return mapper.Map<IEnumerable<MovieDto>>(await movies.GetAsync(selector:x=>x,
		//		                                                           predicate:x=> res.Any(z=>z.Id == x.Id),
		//																   include: item=>item
		//																		   .Include(x => x.Country)
		//																           .Include(x => x.Quality)
		//																           .Include(x => x.Premium)));
		//}

		public async Task CreateAsync(MovieModel movie)
		{
			await movies.InsertAsync(await setData(movie, false));
			await movies.SaveAsync();

		}

		public async Task UpdateAsync(MovieModel movie)
		{
			movies.Update(await setData(movie, true));
			await movies.SaveAsync();
		}

		public async Task<double> GetRatingAsync(int id) => (await GetFeedbacksAsync(id)).Average(x => x.Rating);
				
	}
}
