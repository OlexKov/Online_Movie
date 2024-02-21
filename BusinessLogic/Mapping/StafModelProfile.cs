using AutoMapper;
using BusinessLogic.Models;
using DataAccess.Data.Entities;

namespace BusinessLogic.Mapping
{
	public class StafModelProfile :Profile
	{
        public StafModelProfile()
        {
            CreateMap<Staf, StafModel>()
                .ForMember(x => x.Roles, opt => opt
                .MapFrom(x => x.StafStafRoles
                .Where(z => z.StafId == x.Id).Select(c => c.StafRoleId)))
                .ForMember(x => x.Movies, opt => opt
                .MapFrom(x => x.StafMovies
                .Where(z => z.StafId == x.Id).Select(c => c.MovieId)));
            CreateMap<StafModel, Staf>();
		}
    }
}
