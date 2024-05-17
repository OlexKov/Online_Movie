using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.ModelDto;


namespace BusinessLogic.Mapping
{
	public class MovieModelProfile : Profile
	{
		public MovieModelProfile() { }
		public MovieModelProfile(string url)
		{
			CreateMap<Movie, MovieModel>()
			.ForMember(x => x.Poster, opt => opt
			.MapFrom(x => $"{url}/{x.Poster}"))
			.ForMember(x => x.DateDuration, opt => opt.MapFrom(x => x.Date))
			.ForMember(x => x.Stafs, opt => opt.MapFrom(x => x.StafMovieRoles.Select(z => z.StafId)))
			.ForMember(x => x.ScreenShots, opt => opt.MapFrom(x => x.ScreenShots.Select(z => z.Id)))
			.ForMember(x => x.Genres, opt => opt.MapFrom(x => x.MovieGenres.Select(z => z.GenreId)));
			CreateMap<MovieModel, Movie>()
				.ForMember(x => x.Date, opt => opt.MapFrom(x => x.DateDuration))
				.ForMember(x => x.Poster, opt => opt.MapFrom(x => Path.GetFileName(x.Poster)))
				.ForMember(x => x.ScreenShots, opt => opt.Ignore());
		}
	}
}
