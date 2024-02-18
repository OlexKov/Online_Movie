using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
	public class MovieGenre : BaseEntity
	{
		public Movie Movie { get; set; }
		public int MovieId { get; set; }
		public Genre Genre { get; set; }
		public int GenreId { get; set; }
	}
}
