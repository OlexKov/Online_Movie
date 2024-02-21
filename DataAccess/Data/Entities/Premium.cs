using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.RateLimiting;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
	public class Premium : NameBaseEntity
	{
		public int Rate { get; set; }
		public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
		public ICollection<User> Users { get; set; } = new HashSet<User>();
	}
}
