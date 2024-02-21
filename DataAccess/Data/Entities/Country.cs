using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Data.Entities
{
    public class Country : NameBaseEntity
	{
		public ICollection<Staf> Stafs { get; set; } = new HashSet<Staf>();
		public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
	}
}
