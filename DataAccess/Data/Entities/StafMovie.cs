using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
	public class StafMovie : BaseEntity
	{
		public int StafId { get; set; }
		public Staf Staf { get; set; }
		public int MovieId { get; set; } 
		public Movie Movie { get; set; }
	}
}
