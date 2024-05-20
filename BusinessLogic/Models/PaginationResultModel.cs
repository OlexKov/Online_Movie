using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Models
{
	public class PaginationResultModel<T> where T: class
	{
		public List<T> Elements { get; set; } = [];
		public int TotalCount { get; set; }
		public PaginationResultModel(IEnumerable<T> items, int pageIndex, int pageSize)
		{
			TotalCount = items.Count();
			if (pageSize > 0)
			{
				int totalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
				if (pageIndex > totalPages)
					pageIndex = totalPages;
			}
			else pageSize = TotalCount;
			pageIndex = pageIndex <= 0 ? 1 : pageIndex;
			Elements.AddRange(items.Skip((pageIndex - 1) * pageSize).Take(pageSize));
		}
	}
}
