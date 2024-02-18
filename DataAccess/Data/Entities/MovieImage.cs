using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
	public class MovieImage : BaseEntity
	{
		public Image Image { get; set; }
		public int ImageId { get; set; }
		public Movie Movie { get; set; }
		public int MovieId { get; set; }
	}
}
