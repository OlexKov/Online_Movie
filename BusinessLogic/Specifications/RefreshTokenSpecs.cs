using Ardalis.Specification;
using BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Specifications
{
	public static class RefreshTokenSpecs
	{
		public class GetTokenByValue : Specification<RefreshToken>
		{
			public GetTokenByValue(string token) => Query.Where(x => x.Token == token);
		}
		public class ByDate : Specification<RefreshToken>
		{
			public ByDate(DateTime date)
			{
				Query.Where(x => x.CreationDate < date);
			}
		}
	}
}
