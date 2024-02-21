using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Data.Entities;

namespace BusinessLogic.Mapping
{
	public class MovieProfile : Profile
	{
		public MovieProfile() 
		{
			CreateMap<Movie, MovieDto>()
				.ForMember(x => x.Date, opt => opt.MapFrom(x => DateOnly.FromDateTime(x.Date)))
				.ForMember(x => x.Duration, opt => opt.MapFrom(x => TimeOnly.FromDateTime(x.Date)))
				.ForMember(x => x.QualityName, opt => opt.MapFrom(x => x.Quality.Name))
				.ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Country.Name))
				.ForMember(x => x.PremiumName, opt => opt.MapFrom(x => x.Premium.Name));
			CreateMap<MovieDto, Movie>()
				.ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToDateTime(x.Duration)));
		}
	}
}
