using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class MovieStaf
	{
		public int StafId { get; set; }
		public List<int> MovieRoles { get; set; } = [];
	}
}
