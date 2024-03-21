using Ardalis.Specification;
using BusinessLogic.Data.Entities;

namespace BusinessLogic.Specifications
{
	public static class MovieGenreSpecs
	{
		public class GetByMovieId : Specification<MovieGenre>
		{
			public GetByMovieId(int id)
			{
				Query
					 .Where(x => x.MovieId == id)
					 .Include(x => x.Genre);
			}
		}
	}
}
