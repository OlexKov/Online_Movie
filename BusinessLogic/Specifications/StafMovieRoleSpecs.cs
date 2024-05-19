using Ardalis.Specification;
using BusinessLogic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLogic.Specifications
{
	public static class StafMovieRoleSpecs 
	{
		public class GetMovieRoles : Specification<StafMovieRole>
		{
			public GetMovieRoles(int stafId,int movieId)
			{
				Query.Where(x => x.MovieId == movieId && stafId == x.StafId)
					.Include(x => x.StafRole);
			}
		}


		public class GetMoviesByStafId : Specification<StafMovieRole>
		{
			public GetMoviesByStafId(int id)
			{
				Query
					.Where(x => x.StafId == id)
					.Include(x => x.Movie);
			}
		}

		public class GetStafsByMovieId : Specification<StafMovieRole>
		{
			public GetStafsByMovieId(int id)
			{
				Query
					.Where(x => x.MovieId == id)
					.Include(x => x.Staf)
					.ThenInclude(x => x.Country);
			}
		}
		public class GetMovieByStafIdInc : Specification<StafMovieRole>
		{
			public GetMovieByStafIdInc(int id)
			{
				Query
					.Where(x => x.StafId == id)s
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
