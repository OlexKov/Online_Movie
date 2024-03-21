using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapping
{
	public  class ImageProfile : Profile
	{
		public ImageProfile() { }
		public ImageProfile(string url) 
		{
			CreateMap<Image, ImageDto>()
				.ForMember(x => x.Name, opt => opt
				.MapFrom(x => $"{url}/{x.Name}"));

			CreateMap<ImageDto, Image>()
				.ForMember(x => x.Name, opt => opt.MapFrom(x => Path.GetFileName(x.Name)));
		}
	}
}
