using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Mapping
{
	public class StafProfile :Profile
	{
		public StafProfile() { }

		public StafProfile(string url)
        {
			CreateMap<Staf, StafDto>()
				.ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Country.Name))
				.ForMember(x => x.ImageName, opt => opt
				.MapFrom(x => $"{url}/{x.ImageName}"));

			CreateMap<StafDto, Staf>()
				.ForMember(x => x.ImageName, opt => opt.MapFrom(x => Path.GetFileName(x.ImageName)));

		}
    }
}
