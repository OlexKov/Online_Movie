using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;


namespace BusinessLogic.Mapping
{
	public class FeedbackProfile : Profile
 	{
        public FeedbackProfile()
        {
           CreateMap<FeedbackDto, Feedback>().ReverseMap();
               
		}
    }
}
