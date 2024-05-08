using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace Online_Movie.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController(IAccountsService accountsService) : ControllerBase
	{
		private readonly IAccountsService accountsService = accountsService;

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
		public async Task<IActionResult> Logout([FromBody] LogoutModel token)
		{
			await accountsService.Logout(token.Token);
			return Ok();
		}

		[AllowAnonymous]
		[HttpPost("fogot")]
		public async Task<IActionResult> FogotPassword([FromBody] FogotPasswordModel fogotModel)
		{
			await accountsService.ResetPasswordRequest(fogotModel);
			return Ok();
		}

		[AllowAnonymous]
		//[ValidateAntiForgeryToken]
		[HttpPost("resetpassword")]
		public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
		{
			await accountsService.ResetPassword(model);
			return Ok();
		}

		[HttpGet("getresettoken/{*email}")]
		public async Task<IActionResult> GetResetToken([FromRoute] string email) => Ok(await accountsService.GetResetToken(email));
				
		[AllowAnonymous]
		[HttpPost("refreshtokens")]
		public async Task<IActionResult> RefreshTokens([FromBody] AuthResponse tokens ) => Ok(await accountsService.RefreshTokens(tokens));


		[HttpPut("edit")]
		public async Task<IActionResult> Edit([FromBody] EditUserModel user)
		{
			await accountsService.Edit(user);
			return Ok();
		}

		[HttpDelete("delete/{*email}")]
		public async Task<IActionResult> Delete([FromRoute]string email)
		{
			await accountsService.Delete(email);
			return Ok();
		}

		[HttpGet("getfavourits/{*email}")]
		public async Task<IActionResult> GetFavourits([FromRoute] string email) => Ok(await accountsService.GetFavourits(email));

		[HttpGet("getpremium/{*email}")]
		public async Task<IActionResult> GetPremium([FromRoute] string email)
		{
			var prem = await accountsService.GetPremium(email);
			return Ok(prem);
		}

		[HttpPost("addremovefavourite")]
		public async Task<IActionResult> AddRemoveFavourite([FromBody] FavouriteRequestModel model)
		{
			await accountsService.AddRemoveFavourite(model.Email, model.FavouriteId);
			return Ok();
		}

	}
}
