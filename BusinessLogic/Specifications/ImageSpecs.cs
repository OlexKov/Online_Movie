using Ardalis.Specification;
using BusinessLogic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLogic.Specifications
{
	public static class ImageSpecs
	{
		public class GetByIds : Specification<Image>
		{
			public GetByIds(IEnumerable<int> ids) => Query.Where(x => ids.Contains(x.Id));
		}

		public class GetByMovieId : Specification<Image>
		{
			public GetByMovieId(int movieId) => Query.Where(x => x.MovieId == movieId);
		}
	}
}
