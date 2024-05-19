using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class FindResultModel<T> where T: class
	{
		public IEnumerable<T> Elements { get; set; } = [];
		public int TotalCount { get; set; }
	}
}
