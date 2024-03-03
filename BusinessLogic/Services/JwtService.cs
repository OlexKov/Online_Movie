using BusinessLogic.Data.Entities;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BusinessLogic.Services
{
	internal class JwtService : IJwtService
	{
		private readonly IConfiguration configuration;
		private readonly UserManager<User> userManager;

		public JwtService(IConfiguration configuration,UserManager<User> userManager)
		{
			this.configuration = configuration;
			this.userManager = userManager;
		}

		public IEnumerable<Claim> GetClaims(User user)
		{
			var claims = new List<Claim>
			{
				new (ClaimTypes.NameIdentifier, user.Id),
				new (ClaimTypes.Name, user.UserName),
			};

			var roles = userManager.GetRolesAsync(user).Result;
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
			var jwtOpts = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>()
				?? throw new HttpException(Errors.InvalidGwtSettings,System.Net.HttpStatusCode.InternalServerError);
			var credentials = getCredentials(jwtOpts);
			var token = new JwtSecurityToken(
				issuer: jwtOpts.Issuer,
				claims: claims,
				expires: DateTime.UtcNow.AddMinutes(jwtOpts.Lifetime),
				signingCredentials: credentials);
			return new JwtSecurityTokenHandler().WriteToken(token);
		}

	}
}
