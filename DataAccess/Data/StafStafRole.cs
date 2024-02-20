using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
	public  class StafStafRole : BaseEntity
	{
		public Staf Staf { get; set; }
		public int StafId { get; set; }
		public StafRole StafRole { get; set; }
		public int StafRoleId { get; set; }
	}
}
