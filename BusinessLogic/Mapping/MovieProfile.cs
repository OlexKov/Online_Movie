using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Mapping
{
	public class MovieProfile : Profile
	{
		public MovieProfile() { }
		public MovieProfile(string url) 
		{
			CreateMap<Movie, MovieDto>()
				.ForMember(x=>x.Poster,opt=>opt
				.MapFrom(x=> $"{url}/{x.Poster}"))
				.ForMember(x => x.Date, opt => opt.MapFrom(x => DateOnly.FromDateTime(x.Date)))
				.ForMember(x => x.Duration, opt => opt.MapFrom(x => TimeOnly.FromDateTime(x.Date)))
				.ForMember(x => x.QualityName, opt => opt.MapFrom(x => x.Quality.Name))
				.ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Country.Name))
				.ForMember(x => x.PremiumName, opt => opt.MapFrom(x => x.Premium.Name));

			CreateMap<MovieDto, Movie>()
				.ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToDateTime(x.Duration)))
				.ForMember(x => x.Poster, opt => opt.MapFrom(x => Path.GetFileName(x.Poster)));

			CreateMap<Movie, MovieModel>()
				.ForMember(x => x.DateDuration, opt => opt.MapFrom(x => x.Date))
				.ForMember(x=>x.Stafs,opt=>opt.MapFrom(x=>x.StafMovies.Select(z=>z.StafId)))
				.ForMember(x => x.ScreenShots, opt => opt.MapFrom(x => x.ScreenShots.Select(z => z.Id)))
				.ForMember(x => x.Genres, opt => opt.MapFrom(x => x.MovieGenres.Select(z => z.GenreId)));
			CreateMap<MovieModel, Movie>()
				.ForMember(x => x.Date, opt => opt.MapFrom(x => x.DateDuration)); 
		}
	}
}
