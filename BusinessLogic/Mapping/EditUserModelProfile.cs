using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapping
{
	public class EditUserModelProfile : Profile
	{
		public EditUserModelProfile()
		{
			CreateMap<User, EditUserModel>().ReverseMap();
		}
	}
}
