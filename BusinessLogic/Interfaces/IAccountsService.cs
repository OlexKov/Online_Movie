using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;

namespace BusinessLogic.Interfaces
{
	public  interface IAccountsService
	{
		Task ResetPasswordRequest(FogotPasswordModel fogotModel);
		Task<string> GetResetToken(string email);
		Task ResetPassword(ResetPasswordModel model);
		Task Register(RegisterUserModel model);
		Task Delete(User user);
		Task Delete(string email);
		Task<AuthResponse> Login(AuthRequest model);
		Task Logout(string token);
		Task<RefreshToken> GetRefreshToken(string rToken);
		Task<AuthResponse> RefreshTokens(AuthResponse tokens);
		Task Edit(EditUserModel user);
		Task RemoveExpiredRefreshTokens();
		Task AddRemoveFavourite(string userName, int movieId);
		Task SetPremium(string userName, int premiumId, int days);
		Task<PremiumDto?> GetPremium(string userName);
		Task<IEnumerable<MovieDto>> GetFavourits(string userName);
		Task<IEnumerable<MovieDto>> GetFavourits(User user);
	}
}
