using BusinessLogic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Entities
{
	public class RefreshToken : BaseEntity
	{
		public string Token { get; set; }
		public DateTime CreationDate { get; set; }
		public string UserId { get; set; }
		public User? User { get; set; }
	}
}
