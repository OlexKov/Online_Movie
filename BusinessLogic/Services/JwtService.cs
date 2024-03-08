using BusinessLogic.Data.Entities;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLogic.Services
{
	internal class JwtService : IJwtService
	{
		private readonly UserManager<User> userManager;
		private JwtOptions jwtOpts;

		public JwtService(IConfiguration configuration,UserManager<User> userManager)
		{
			this.userManager = userManager;
			jwtOpts = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()
				?? throw new HttpException(Errors.InvalidGwtSettings, HttpStatusCode.InternalServerError);
		}

		public async Task<IEnumerable<Claim>> GetClaimsAsync(User user)
		{
			var claims = new List<Claim>
			{
				new (ClaimTypes.NameIdentifier, user.Id),
				new (ClaimTypes.Name, user.UserName!),
			};

			var roles = await userManager.GetRolesAsync(user);
			claims.AddRange(roles.Select(role => new Claim(ClaimsIdentity.DefaultRoleClaimType, role)));

			return claims;
		}

		private SigningCredentials getCredentials(JwtOptions options)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(options.Key));
			return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
		}

		public string CreateToken(IEnumerable<Claim> claims)
		{
			var credentials = getCredentials(jwtOpts);
			var token = new JwtSecurityToken(
				issuer: jwtOpts.Issuer,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(jwtOpts.AccessTokenLifeTimeMinutes),
				signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

		public string CreateRefreshToken()
		{
			var randomNumber = new byte[64];
			using var rng = RandomNumberGenerator.Create();
			rng.GetBytes(randomNumber);
			return Convert.ToBase64String(randomNumber);
		}

		public IEnumerable<Claim> GetClaimsFromExpiredToken(string token)
		{
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = false,
				ValidateLifetime = false,
				ValidateIssuerSigningKey = true,
				ValidIssuer = jwtOpts.Issuer,
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpts.Key)),
			};

			var tokenHandler = new JwtSecurityTokenHandler();

			tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);

			if (securityToken is not JwtSecurityToken jwtSecurityToken ||
				!jwtSecurityToken.Header.Alg
					.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
			{
				throw new HttpException(Errors.InvalidToken, HttpStatusCode.BadRequest);
			}

			return jwtSecurityToken.Claims;
		}

		public DateTime GetLastValidTokenDate() => DateTime.UtcNow.AddDays(jwtOpts.RefreshTokenLifeTimeDays);
		
	}
}
