using Ardalis.Specification;
using BusinessLogic.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BusinessLogic.Specifications
{
	public static class MovieGenreSpecs
	{
		public class GetByMovieId : Specification<MovieGenre>
		{
			public GetByMovieId(int id)
			{
				Query
					 .Where(x => x.MovieId == id)
					 .Include(x => x.Genre);
			}
		}
	}
}
