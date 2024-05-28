using BusinessLogic.Data.Entities;
using BusinessLogic;
using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;
using BusinessLogic.Specifications;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;

namespace Online_Movie.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/[controller]")]
	[ApiController]
	public class AccountsController(IAccountsService accountsService) : ControllerBase
	{
		private readonly IAccountsService accountsService = accountsService;

		[HttpGet("getresettoken/{*email}")]
		public async Task<IActionResult> GetResetToken([FromRoute] string email) => Ok(await accountsService.GetResetToken(email));

		[HttpGet("getfavourites")]
		public async Task<IActionResult> GetFavourites([FromQuery] string email) => Ok(await accountsService.GetFavouritesAsync(email));

		[HttpGet("getpremium")]
		public async Task<IActionResult> GetPremium([FromQuery] string email)
		{
			var prem = await accountsService.GetPremium(email);
			return Ok(prem);
		}

		[HttpGet("ismoviefauvorite")]
		public async Task<IActionResult> IsMovieFauvorite([FromQuery] int movieId, string userId) => Ok(await accountsService.IsMovieFauvorite(movieId, userId));
		

		[AllowAnonymous]
		[HttpPost("register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserModel model)
		{
			await accountsService.Register(model);
			return Ok();
		}

		[HttpPost("addremovefavourite")]
		public async Task<IActionResult> AddRemoveFavourite([FromBody] FavouriteRequestModel model) => Ok(await accountsService.AddRemoveFavourite(model.Email, model.MovieId));
		

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


	}
}
