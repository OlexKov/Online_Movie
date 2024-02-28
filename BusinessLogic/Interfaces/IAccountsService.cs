using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
	public  interface IAccountsService
	{
		Task<ResetPasswordResponse> ResetPasswordRequest(string email);
		Task ResetPassword(ResetPasswordModel model);
		Task Register(RegisterModel model);
		Task Login(LoginModel model);
		Task Logout();
	}
}
