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
		Task ResetPassword(ResetPasswordModel model);
		Task RegisterUserAsync(RegisterUserModel model);
		Task RegisterAdminAsync(RegisterUserModel model);
		Task DeleteAsync(User user);
		Task Delete(string email);
		Task<AuthResponse> LoginAsync(AuthRequest model);
		Task LogoutAsync(string token);
		Task<RefreshToken> GetRefreshTokenAsync(string rToken);
		Task<AuthResponse> RefreshTokensAsync(AuthResponse tokens);
		Task<string> EditAsync(EditUserModel user);
		Task RemoveExpiredRefreshTokens();
		Task<bool> AddRemoveFavourite(string userName, int movieId);
		Task<bool> IsMovieFauvorite(int movieId, string userId);
		Task<string> SetPremiumAsync(string userName, int premiumId, int days);
		Task<PremiumDto?> GetPremiumAsync(string userName);
		Task<IEnumerable<MovieDto>> GetFavouritesAsync(string userName);
		Task<IEnumerable<MovieDto>> GetFavouritesAsync(User user);
	}
}
