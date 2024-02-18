using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
	public class StafRole : NameBaseEntity
	{
		public IEnumerable<Staf> Stafs { get; set; } = new HashSet<Staf>();
	}
}
