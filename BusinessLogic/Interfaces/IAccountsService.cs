using BusinessLogic.Data.Entities;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
	public  interface IAccountsService
	{
		Task<ResetPasswordResponse> ResetPasswordRequest(string email);
		Task ResetPassword(ResetPasswordModel model);
		Task Register(RegisterModel model);
		Task Delete(User user);
		Task Delete(string email);
		Task<LoginJwtResponse> Login(LoginModel model);
		Task Logout();
	}
}
