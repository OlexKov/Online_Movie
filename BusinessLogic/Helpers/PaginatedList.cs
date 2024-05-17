using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Helpers
{
	public class PaginatedList<T> : List<T>
	{
		public int TotalCount { get; private set; }

		public PaginatedList(IEnumerable<T> items,  int pageIndex, int pageSize)
		{
			TotalCount = items.Count();
			if (pageSize > 0)
			{
				int totalPages = (int)Math.Ceiling(TotalCount / (double)pageSize);
				if (pageIndex > totalPages)
					  pageIndex = totalPages;
			}
			else pageSize = TotalCount;
			this.AddRange(items.Skip((pageIndex - 1) * pageSize).Take(pageSize));
		}
	}
}
