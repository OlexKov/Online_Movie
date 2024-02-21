using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Mapping
{
	public class StafProfile :Profile
	{
        public StafProfile()
        {
            CreateMap<Staf, StafDto>()
                .ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.Country.Name));
            CreateMap<StafDto, Staf>();

		}
    }
}
