using AutoMapper;
using BusinessLogic.Data.Entities;
using BusinessLogic.Models;


namespace BusinessLogic.Mapping
{
	public class RegisterModelProfile :Profile
	{
        public RegisterModelProfile()
        {
			CreateMap<RegisterUserModel, User>()
				.ForMember(x => x.UserName, opts => opts.MapFrom(s => s.Email));
		}
    }
}
