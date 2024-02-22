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
	public class FeedbackProfile :Profile
 	{
        public FeedbackProfile()
        {
            CreateMap<Feedback, FeedbackDto>().ReverseMap();
        }
    }
}
