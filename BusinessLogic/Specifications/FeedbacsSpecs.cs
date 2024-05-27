using Ardalis.Specification;
using BusinessLogic.Data.Entities;
using BusinessLogic.Models;
using System.Linq.Expressions;

namespace BusinessLogic.Specifications
{
	public static class FeedbacsSpecs
	{
		public class GetByMovieId : Specification<Feedback>
		{
			public GetByMovieId(int id,bool approved)
			{
				Query.Where(x => x.MovieId == id && x.Approved == approved)
					.Include(x=>x.User);
			}
		}

		public class GetNotApproved : Specification<Feedback>
		{
			public GetNotApproved()
			{
				Query.Where(x => !x.Approved);
	     	}
		}

		public class GetById : Specification<Feedback>
		{
			public GetById(int id)
			{
				Query.Where(x => x.Id == id);
			}
		}

		public class GetByUserId : Specification<Feedback>
		{
			public GetByUserId(string id) => Query.Where(x => x.UserId == id);
		}

		public class HasFeedback : Specification<Feedback>
		{
			public HasFeedback(int movieId,string userId) => Query.Where(x => x.UserId == userId && x.MovieId == movieId);
		}
		public class GetAll : Specification<Feedback>
		{
			public GetAll()
			{
				Query
					.Include(x=>x.User)
					.Include(x=>x.Movie);
			}
			
		}

	}
}
