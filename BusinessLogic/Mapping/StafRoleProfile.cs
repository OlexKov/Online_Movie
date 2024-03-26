using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapping
{
	public class StafRoleProfile :Profile
	{
		public StafRoleProfile()
		{
			CreateMap<StafRole, StafRoleDto>().ReverseMap();
		}
	}
}
