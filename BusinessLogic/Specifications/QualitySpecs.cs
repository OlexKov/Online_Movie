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
	public static class QualitySpecs
	{
		public class GetAll : Specification<Quality>
		{
			public GetAll() => Query.Where(x => true);
		}
	}
}
