using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.Data.Entities
{
    public class StafRole : NameBaseEntity
	{
		public ICollection<StafStafRole> StafStafRoles { get; set; } = new HashSet<StafStafRole>();
	}
}
