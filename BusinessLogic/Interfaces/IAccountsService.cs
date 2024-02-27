using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
	public  interface IAccountsService
	{
		Task<ResetPasswordModel> ResetPasswordRequest(string email);
		Task ResetPassword(ResetPasswordModel model);
		Task Register(RegisterModel model);
		Task Login(LoginModel model);
		Task Logout();
	}
}
