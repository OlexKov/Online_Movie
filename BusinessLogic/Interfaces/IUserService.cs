using BusinessLogic.Data.Entities;
using BusinessLogic.DTOs;


namespace BusinessLogic.Interfaces
{
	public interface IUserService
	{
		Task AddRemoveFavourite(string userName,int movieId);
		Task SetPremium(string userName, int premiumId,int days);
		Task<PremiumDto?> GetPremium(string userName);
		Task<IEnumerable<MovieDto>> GetFavourits(string userName);
		Task<IEnumerable<MovieDto>> GetFavourits(User user);

	}
}
