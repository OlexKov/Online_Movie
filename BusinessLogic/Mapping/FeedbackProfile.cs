using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.Models;


namespace BusinessLogic.Mapping
{
	public class FeedbackProfile : Profile
 	{
        public FeedbackProfile()
        {
            CreateMap<FeedbackDto, Feedback>();

            CreateMap<Feedback, FeedbackDto>()
                 .ForMember(x => x.Name, opt => opt.MapFrom(z => z.User.Name))
                 .ForMember(x => x.Surname, opt => opt.MapFrom(z => z.User.Surname));

            CreateMap<FeedbackCreationModel, Feedback>();
  		}
    }
}
