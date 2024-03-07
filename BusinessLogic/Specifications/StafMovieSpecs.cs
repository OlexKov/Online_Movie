using Ardalis.Specification;
using BusinessLogic.Data.Entities;

namespace BusinessLogic.Specifications
{
	public static class StafMovieSpecs
	{
		public class GetByStafId : Specification<StafMovie>
		{
			public GetByStafId(int id)
			{
				Query
					.Where(x => x.StafId == id)
					.Include(x => x.Movie);
			}
		}

		public class GetByMovieId : Specification<StafMovie>
		{
			public GetByMovieId(int id)
			{
				Query
					.Where(x => x.MovieId == id)
					.Include(x => x.Staf);
			}
		}
		public class GetMovieByStafIdInc : Specification<StafMovie>
		{
			public GetMovieByStafIdInc(int id)
			{
				Query
					.Where(x => x.StafId == id)
					.Include(x => x.Movie)
					.ThenInclude(x => x.Country)
					.Include(x => x.Movie)
					.ThenInclude(x => x.Quality)
					.Include(x => x.Movie)
					.ThenInclude(x => x.Premium);
			}
		}
	}
}
