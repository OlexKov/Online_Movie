using Ardalis.Specification;
using BusinessLogic.Data.Entities;
using System;


namespace BusinessLogic.Specifications
{
	public static class CountrySpecs
	{
		public class GetAll : Specification<Country>
		{
			public GetAll() => Query.Where(x=>true);
		}
	}
}
