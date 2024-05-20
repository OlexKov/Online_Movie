using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;
using BusinessLogic.Resources;
using BusinessLogic.Specifications;
using FluentValidation;
using System.Net;
using System.Text.Json;


namespace BusinessLogic.Services
{
	internal class MovieService : IMovieService
	{
		private readonly IRepository<Movie> movies;
		private readonly IRepository<Feedback> feedbacks;
		private readonly IRepository<StafMovieRole> stafMovies;
		private readonly IRepository<MovieGenre> movieGenres;
		private readonly IRepository<Image> images;
		private readonly IMapper mapper;
		private readonly IImageService imageService;
		private readonly IValidator<MovieModel> validator;
		
		private async Task deleteMovieDependencies(int id)
		{
			var stafs = await stafMovies.GetListBySpec(new StafMovieRoleSpecs.GetStafsByMovieId(id));
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
			{
				await deleteMovieDependencies(movie.Id);
				var screensIds = (await images.GetListBySpec(new ImageSpecs.GetByMovieId(movie.Id))).Select(x => x.Id);
				await imageService.DeleteImegeRangeAsync(screensIds.Except(movieModel.ScreenShots));
			}
			List<MovieStaf> movieStafs = [];
			var options = new JsonSerializerOptions
			{
				PropertyNameCaseInsensitive = true
			};
			foreach (var jsonStr in movieModel.Stafs)
				movieStafs.Add(JsonSerializer.Deserialize<MovieStaf>(jsonStr, options)! );
			foreach (var movieStaf in movieStafs)
			{
				foreach(var role in movieStaf.MovieRoles)
			    	movie.StafMovieRoles.Add(new() { MovieId = movie.Id, StafId = movieStaf.StafId, StafRoleId = role });
			}
			foreach (var id in movieModel.Genres)
				movie.MovieGenres.Add(new() { MovieId = movie.Id, GenreId = id });
			foreach (var item in movieModel.Screens)
				movie.ScreenShots.Add(new() { MovieId = movie.Id, Name = await imageService.SaveImageAsync(item) });
			
			if (movieModel.PosterFile != null)
			{
			   if (update && movie.Poster != null && movie.Poster != "nophoto.jpg")
					imageService.DeleteImageByName(movieModel.Poster ?? "");
				movie.Poster = await imageService.SaveImageAsync(movieModel.PosterFile);
			}
			return movie;
		}


		public MovieService(IRepository<Movie> movies,
			                IRepository<Feedback> feedbacks,
			                IRepository<StafMovieRole> stafMovie,
							IRepository<MovieGenre> movieGenre,
			                IRepository<Image> images,
							IMapper mapper,
							IImageService imageService,
							IValidator<MovieModel> validator)
		{
			this.movies = movies;
			this.feedbacks = feedbacks;
			this.stafMovies = stafMovie;
			this.movieGenres = movieGenre;
			this.images = images;
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
			if(movie.Poster != null && movie.Poster != "nophoto.jpg")
			  imageService.DeleteImageByName(movie.Poster);
		} 

		public async Task<IEnumerable<MovieDto>> GetAllAsync() => mapper.Map<IEnumerable<MovieDto>>(await movies.GetListBySpec(new MovieSpecs.GetAll()));
		

		public async Task<MovieDto> GetByIdAsync(int id)
		{
			return id < 0
				? throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest)
				: mapper.Map<MovieDto>(await movies.GetItemBySpec(new MovieSpecs.GetByIdInc(id)) 
				?? throw new HttpException(Errors.NotFoundById, HttpStatusCode.NotFound));
		}

		public async Task<PaginationResultModel<FeedbackDto>> GetFeedbacksAsync(int id,bool approved, int pageIndex, int pageSize)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			var feedBacks = mapper.Map<IEnumerable<FeedbackDto>>(await feedbacks.GetListBySpec(new FeedbacsSpecs.GetByMovieId(id, approved)));
			return new PaginationResultModel<FeedbackDto>(feedBacks, pageIndex, pageSize);
		}

		public async Task<IEnumerable<ImageDto>> GetScreensAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			return await imageService.GetByMovieId(id);
		}

		public async Task<IEnumerable<StafDto>> GetStafAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			return mapper.Map<IEnumerable<StafDto>>((await stafMovies.GetListBySpec(new StafMovieRoleSpecs.GetStafsByMovieId(id)))
				         .Select(x=>x.Staf)
						 .Distinct());
		}
		
		public async Task<IEnumerable<MovieDto>> GetTopByRatingAsync(int count)
		{
			var topMovies = (await movies.GetListBySpec(new MovieSpecs.GetAllIncFeedbacks()))
							   .Select(x => new { movie = x, avarege = x.Feedbacks.Average(z => z.Rating) })
							   .OrderByDescending(x => x.avarege)
							   .Take(count)
							   .Select(x => x.movie);

			return mapper.Map<IEnumerable<MovieDto>>(topMovies);																		
		}

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

		public async Task<double> GetRatingAsync(int id) 
		{
			var feedbacks = await GetFeedbacksAsync(id,true,0,0);
			return feedbacks.Elements.Any() ? feedbacks.Elements.Average(x => x.Rating) : 0;
			
		}

		public async Task<IEnumerable<MovieDto>> FindAsync(MovieFindFilterModel movieFilter) => mapper.Map<IEnumerable<MovieDto>>(await movies.GetListBySpec(new MovieSpecs.Find(movieFilter)));

		public async Task<IEnumerable<GenreDto>> GetGenresAsync(int id)
		{
			if (id < 0) throw new HttpException(Errors.NegativeId, HttpStatusCode.BadRequest);
			return mapper.Map<IEnumerable<GenreDto>>((await  movieGenres.GetListBySpec(new MovieGenreSpecs.GetByMovieId(id)))
				         .Select(x=>x.Genre));
		}

		public async Task<PaginationResultModel<MovieDto>> GetMovieFilteredPaginationAsync(FilteredPaginationModel model)
		{
			IEnumerable<MovieDto> filteredMovies = model.FindModel != null 
				                  ? mapper.Map<IEnumerable<MovieDto>>(await movies.GetListBySpec(new MovieSpecs.Find(model.FindModel)))
								  : await GetAllAsync();
			return new PaginationResultModel<MovieDto>(filteredMovies, model.PageIndex, model.PageSize);
		}

		public async Task<bool> HasFeedbackAsync(int movieId, string userId)
		{
			var res = await feedbacks.GetItemBySpec(new FeedbacsSpecs.HasFeedback(movieId, userId));
			return res != null;
		} 
		
	}
}
