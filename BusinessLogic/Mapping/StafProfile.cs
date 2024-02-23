using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;

namespace BusinessLogic.Mapping
{
	public class StafProfile :Profile
	{
        public StafProfile()
        {
            CreateMap<Staf, StafDto>()
                .ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Country.Name));
            CreateMap<StafDto, Staf>();

		}
    }
}
