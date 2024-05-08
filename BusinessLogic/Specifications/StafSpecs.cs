using Ardalis.Specification;
using BusinessLogic.Data.Entities;

namespace BusinessLogic.Specifications
{
	public static class StafSpecs
	{
		
		public class GetById : Specification<Staf>
		{
			public GetById(int id)
			{
				Query
					.Where(x => x.Id == id)
					.Include(x => x.Country);
			}
		}

		public class GetByIdIncCol : Specification<Staf>
		{
			public GetByIdIncCol(int id)
			{
				Query
					.Where(x => x.Id == id)
					.Include(x => x.StafMovies)
					.Include(x => x.StafStafRoles);
			}
		}

		public class GetByIds : Specification<Staf>
		{
			public GetByIds(IEnumerable<int> ids)
			{
				Query
					.Where(x => ids.Contains(x.Id))
					.Include(x => x.Country);
			}
		}

		public class GetAll : Specification<Staf>
		{
			public GetAll() => Query.Include(x => x.Country);
			
		}

		public class Take : Specification<Staf>
		{
			public Take(int skip, int count)
			{
				Query
					.Skip(skip)
					.Take(count)
					.Include(x => x.Country);
			}
		}
	}
}
