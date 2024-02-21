using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Data.Entities
{
    public class Genre : NameBaseEntity
	{
		public ICollection<MovieGenre> MovieGenres { get; set; } = new HashSet<MovieGenre>();
	}
}
