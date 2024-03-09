using Ardalis.Specification;
using BusinessLogic.Data.Entities;
using BusinessLogic.Models;
using System.Linq.Expressions;



namespace BusinessLogic.Specifications
{
	public static class MovieSpecs
	{
		public class GetByIdIncCollections : Specification<Movie>
		{
			public GetByIdIncCollections(int id)
			{
				Query
					.Where(x => x.Id == id)
					.Include(x => x.Feedbacks)
					.Include(x => x.MovieGenres)
					.Include(x => x.StafMovies)
					.Include(x => x.UserMovies)
					.Include(x => x.ScreenShots);
			}
		}
		public class GetByIdInc : Specification<Movie>
		{
			public GetByIdInc(int id)
			{
				Query
					.Where(x => x.Id == id)
					.Include(x => x.Country)
					.Include(x => x.Quality)
					.Include(x => x.Premium);
			}
		}

		public class GetAll : Specification<Movie>
		{
			public GetAll()
			{
				Query
					.Include(x => x.Country)
					.Include(x => x.Quality)
					.Include(x => x.Premium);
			}
		}

		public class Find : Specification<Movie>
		{
			public Find(MovieFindFilterModel movieFilter)
			{
				 
				Query
					.Where(advertFilter(movieFilter))
					.Include(x => x.Country)
					.Include(x => x.Quality)
					.Include(x => x.Premium);
			}
			private Expression<Func<Movie, bool>> advertFilter(MovieFindFilterModel movieFilter)
			{
				Expression<Func<Movie, bool>> TmpExpr;
				Expression<Func<Movie, bool>> ResultExp = x=>true;
				Expression<Func<Movie, bool>> NameExpr = x => x.Name == movieFilter.Name;
				Expression<Func<Movie, bool>> OrNameExpr = x => x.OriginalName == movieFilter.OriginalName;
				Expression<Func<Movie, bool>> YearExpr = x => movieFilter.Years.Contains(x.Date.Year);
				Expression<Func<Movie, bool>> QualityExpr = x => movieFilter.Qualities.Contains(x.QualityId);
				Expression<Func<Movie, bool>> CountryExpr = x =>  movieFilter.Countries.Contains(x.CountryId);
				
				if (!string.IsNullOrEmpty(movieFilter.Name))
					ResultExp = ResultExp.AndAlso(NameExpr);
				if (!string.IsNullOrEmpty(movieFilter.OriginalName))
					ResultExp = ResultExp.AndAlso(OrNameExpr);
				if (movieFilter.Years != null && movieFilter.Years.Count != 0)
					ResultExp = ResultExp.AndAlso(YearExpr);
				if (movieFilter.Qualities != null && movieFilter.Qualities.Count != 0)
					ResultExp = ResultExp.AndAlso(QualityExpr);
				if (movieFilter.Countries != null && movieFilter.Countries.Count != 0)
					ResultExp = ResultExp.AndAlso(CountryExpr);
				if (movieFilter.Stafs != null || movieFilter.Stafs.Count != 0)
				{
					if (movieFilter.AllStafs)
						TmpExpr = x => movieFilter.Stafs.All(z => x.StafMovies.Any(y => y.StafId == z));
					else
						TmpExpr = x => x.StafMovies.Any(x => movieFilter.Stafs.Contains(x.StafId));
					ResultExp = ResultExp.AndAlso(TmpExpr);
				}
				if (movieFilter.Genres != null || movieFilter.Genres.Count != 0)
				{
					if (movieFilter.AllGenres)
						TmpExpr = x => movieFilter.Genres.All(z => x.MovieGenres.Any(y=>y.GenreId == z));
					else
						TmpExpr = x => x.MovieGenres.Any(x => movieFilter.Genres.Contains(x.GenreId));
					ResultExp = ResultExp.AndAlso(TmpExpr);
				}

				return ResultExp;
     		}
		}


	}
}
