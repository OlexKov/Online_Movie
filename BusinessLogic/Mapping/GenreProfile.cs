using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;

namespace BusinessLogic.Mapping
{
	public class GenreProfile :Profile
	{
		public GenreProfile()
		{
			CreateMap<Genre, GenreDto>().ReverseMap();
		}
	}
}
