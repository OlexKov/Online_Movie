using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
	public class Staf : NameBaseEntity
	{
		public string Surname { get; set; }
		public string Description { get; set; }
		public string? ImageName { get; set; }
		public Country Country { get; set; }
		public int CountryId { get; set; }
		public DateTime Birthdate { get; set; }
		public bool IsOscar { get; set; }
		public ICollection<StafMovie> StafMovies { get; set; } = new HashSet<StafMovie>();
		public ICollection<StafStafRole> StafStafRoles { get; set; } = new HashSet<StafStafRole>();
	}
}
