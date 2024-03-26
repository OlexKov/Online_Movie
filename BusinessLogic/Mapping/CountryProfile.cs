using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;

namespace BusinessLogic.Mapping
{
	public class CountryProfile :Profile
	{
		public CountryProfile()
		{
			CreateMap<Country, CountryDto>().ReverseMap();
		}
	}
}
