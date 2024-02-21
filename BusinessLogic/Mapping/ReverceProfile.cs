using AutoMapper;
using BusinessLogic.DTOs;
using DataAccess.Data.Entities;


namespace BusinessLogic.Mapping
{
    public class ReverceProfile<T,U> : Profile where T : BaseEntity 
                                               where U : BaseDto
    { 
        public ReverceProfile()
        {
            CreateMap<T,U>().ReverseMap();
        }
    }
}
