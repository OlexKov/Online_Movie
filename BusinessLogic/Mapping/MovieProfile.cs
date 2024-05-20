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
				.ForMember(x => x.PremiumName, opt => opt.MapFrom(x => x.Premium.Name))
				.ForMember(x => x.PremiumRate, opt => opt.MapFrom(x => x.Premium.Rate));

			CreateMap<MovieDto, Movie>()
				.ForMember(x => x.Date, opt => opt.MapFrom(x => x.Date.ToDateTime(x.Duration)))
				.ForMember(x => x.Poster, opt => opt.MapFrom(x => Path.GetFileName(x.Poster)));
			
		}
	}
}
