using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class MovieFindFilterModel
	{
		public string? Name { get; set; }
		public string? OriginalName { get; set; }
		public List<int> Years { get; set; } = [];
		public List<int> Qualities { get; set; } = [];
		public List<int> Countries { get; set; } = [];
		public List<int> Stafs { get; set; } = [];
		public bool AllStafs { get; set; } 
		public List<int> Genres { get; set; } = [];
		public bool AllGenres { get; set; }
	}
}
