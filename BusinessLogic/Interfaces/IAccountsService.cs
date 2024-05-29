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
		Task EditAsync(EditUserModel user);
		Task RemoveExpiredRefreshTokens();
		Task<bool> AddRemoveFavourite(string userName, int movieId);
		Task<bool> IsMovieFauvorite(int movieId, string userId);
		Task SetPremiumAsync(string userName, int premiumId, int days);
		Task<PremiumDto?> GetPremiumAsync(string userName);
		Task<IEnumerable<MovieDto>> GetFavouritesAsync(string userName);
		Task<IEnumerable<MovieDto>> GetFavouritesAsync(User user);
	}
}
