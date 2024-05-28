using Ardalis.Specification;
using BusinessLogic.Data.Entities;

namespace BusinessLogic.Specifications
{
	public static class UserSpecs
	{
		public class GetByEmailInc : Specification<User>
		{
			public GetByEmailInc(string email)
			{
				Query
					.Where(x => x.UserName == email)
					.Include(x => x.Premium)
					.Include(x => x.UserMovies)
					.Include(x => x.Feedbacks);
				
			}
		}
	}
}
