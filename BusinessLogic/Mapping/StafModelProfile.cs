using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.ModelDto;

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
            CreateMap<StafModel, Staf>().
                ForMember(x => x.ImageName, opt => opt.MapFrom(x => Path.GetFileName(x.ImageName)));
		}
    }
}
