using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class FilteredPaginationModel
	{
		public MovieFindFilterModel FindModel { get; set; }
       	public int PageSize { get; set; }
		public int PageIndex { get; set; }
	}
}
