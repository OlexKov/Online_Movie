using Ardalis.Specification;
using BusinessLogic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Specifications
{
	public static class StafStafRolesSpecs
	{
		public class GetByStafId : Specification<StafStafRole>
		{
			public GetByStafId(int id) => Query.Where(x => x.StafId == id);
		}

		public class GetByStafIdInc : Specification<StafStafRole>
		{
			public GetByStafIdInc(int id)
			{
				Query
					.Where(x => x.StafId == id)
					.Include(x => x.StafRole);
			}
		}
	}
}
