using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Online_Movie.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController : ControllerBase
	{
		private readonly IAccountsService accountsService;

		public AccountsController(IAccountsService accountsService)
		{
			this.accountsService = accountsService;
		}

		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserModel model)
		{
			await accountsService.Register(model);
			return Ok();
		}

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] AuthRequest model) => Ok(await accountsService.Login(model));

		[HttpPost("logout")]
		public async Task<IActionResult> Logout([FromBody] AuthResponse tokens)
		{
			await accountsService.Logout(tokens);
			return Ok();
		}

		[AllowAnonymous]
		[HttpPost("fogot")]
		public async Task<IActionResult> FogotPassword([FromRoute] string email) => Ok(await accountsService.ResetPasswordRequest(email));

		[HttpPost("reset")]
		public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
		{
			await accountsService.ResetPassword(model);
			return Ok();
		}

		[AllowAnonymous]
		[HttpPost("refreshTokens")]
		public async Task<IActionResult> RefreshTokens([FromBody] AuthResponse tokens ) => Ok(await accountsService.RefreshTokens(tokens));


		[HttpPut("edit")]
		public async Task<IActionResult> Edit([FromBody] EditUserModel user)
		{
			await accountsService.Edit(user);
			return Ok();
		}

		[Authorize(Roles = Roles.Admin)]
		[HttpDelete("delete/{*email}")]
		public async Task<IActionResult> Delete([FromRoute]string email)
		{
			await accountsService.Delete(email);
			return Ok();
		}

		
	}
}
