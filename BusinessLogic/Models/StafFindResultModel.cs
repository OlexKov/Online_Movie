using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class StafFindResultModel
	{
		public IEnumerable<StafDto> Stafs { get; set; } = [];
		public int TotalCount { get; set; }
	}
}
