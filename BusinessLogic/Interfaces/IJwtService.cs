using BusinessLogic.Data.Entities;
using System.Security.Claims;

namespace BusinessLogic.Interfaces
{
	public interface IJwtService
	{
		Task<IEnumerable<Claim>> GetClaimsAsync(User user);
		string CreateToken(IEnumerable<Claim> claims);

		string CreateRefreshToken();
		IEnumerable<Claim> GetClaimsFromExpiredToken(string token);

		DateTime GetLastValidTokenDate();

	}
}
