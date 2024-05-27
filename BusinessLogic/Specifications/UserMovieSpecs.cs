using Ardalis.Specification;
using BusinessLogic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Specifications
{
	public static class UserMovieSpecs 
	{
		public class GetByMovieId : Specification<UserMovie>
		{
			public GetByMovieId(int id) => Query.Where(x => x.MovieId == id).Include(x=>x.User);
		}
		public class GetByUserId : Specification<UserMovie>
		{
			public GetByUserId(string id) => Query.Where(x => x.UserId == id)
				                                  .Include(x=>x.Movie)
				                                  .ThenInclude(x=>x.Quality);
		}

		public class GetUserMovieByMovieId : Specification<UserMovie>
		{
			public GetUserMovieByMovieId(string userId,int movieId) => Query.Where(x => x.UserId == userId && movieId == x.MovieId);
		}
	}
}
