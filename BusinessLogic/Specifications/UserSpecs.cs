using Ardalis.Specification;
using BusinessLogic.Data.Entities;

namespace BusinessLogic.Specifications
{
	public static class UserSpecs
	{
		public class GetByNameInc : Specification<User>
		{
			public GetByNameInc(string name)
			{
				Query
					.Where(x => x.UserName == name)
					.Include(x => x.Premium)
					.Include(x => x.UserMovies)
					.Include(x => x.Feedbacks);
				
			}
		}
	}
}
