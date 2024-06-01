using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;

namespace BusinessLogic.Mapping
{
	public class StafProfile :Profile
	{
		public StafProfile() { }

		public StafProfile(string url)
        {
			CreateMap<Staf, StafDto>()
				.ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Country.Name))
				.ForMember(x => x.ImageName, opt => opt.MapFrom(x => $"{url}/{x.ImageName}"))
				.ForMember(x=>x.Roles,opt=>opt.MapFrom(x=>x.StafStafRoles.Select(z=>z.StafRoleId)))
				.ForMember(x => x.MovieRoles, opt => opt.MapFrom(x => x.StafMovieRoles.Select(z => z.StafRoleId).Distinct())); ;
			    

			CreateMap<StafDto, Staf>()
				.ForMember(x => x.ImageName, opt => opt.MapFrom(x => Path.GetFileName(x.ImageName)));

		}
    }
}
