using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
	public class Image : NameBaseEntity
	{
		public IEnumerable<MovieImage> MovieImages { get; set; } = new HashSet<MovieImage>();
	}
}
