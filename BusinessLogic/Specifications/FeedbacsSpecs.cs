using Ardalis.Specification;
using BusinessLogic.Data.Entities;

namespace BusinessLogic.Specifications
{
	public static class FeedbacsSpecs
	{
		public class GetByMovieId : Specification<Feedback>
		{
			public  GetByMovieId(int id) => Query.Where(x => x.MovieId == id);
		}
		public class GetByUserId : Specification<Feedback>
		{
			public GetByUserId(string id) => Query.Where(x => x.UserId == id);
		}
	}
}
