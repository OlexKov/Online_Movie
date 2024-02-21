using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
	public abstract class NameBaseDto :BaseDto
	{
		public string? Name { get; set; }
	}
}
