using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;


namespace BusinessLogic.Mapping
{
	public class PremiumProfile : Profile
	{
		public PremiumProfile()
		{
			CreateMap<Premium, PremiumDto>().ReverseMap();
			//	.ForMember(x => x.MovieIds, arg => arg.MapFrom(x => x.Movies.Select(x => x.Id).ToList()))
			//	.ForMember(x => x.UserIds, arg => arg.MapFrom(x => x.Users.Select(x => x.Id).ToList()));
			//CreateMap<PremiumDto, Premium>();
		}
	}
}
