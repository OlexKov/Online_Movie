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
	public static class PremiumSpecs
	{
		public class GetAll : Specification<Premium>
		{
			public GetAll() => Query.Where(x => true);
		}
		
	}
}
