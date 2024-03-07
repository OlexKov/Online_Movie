using BusinessLogic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
	public class PremiumDto :NameBaseDto
	{
		public int Rate { get; set; }
		public List<int> MovieIds { get; set; } = [];
		public List<string> UserIds { get; set; } = [];
	}
}
