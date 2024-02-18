using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities
{
	public abstract class NameBaseEntity : BaseEntity
	{
		public string Name { get; set; }
	}
}
