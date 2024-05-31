using BusinessLogic.Data.Entities;
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
	public class AccountsController(IAccountsService accountsService) : ControllerBase
	{
		private readonly IAccountsService accountsService = accountsService;

		[HttpGet("getfavourites")]
		public async Task<IActionResult> GetFavourites([FromQuery] string email) => Ok(await accountsService.GetFavouritesAsync(email));

		[HttpGet("getpremium")]
		public async Task<IActionResult> GetPremium([FromQuery] string email)
		{
			var prem = await accountsService.GetPremiumAsync(email);
			return Ok(prem);
		}

		[HttpGet("ismoviefauvorite")]
		public async Task<IActionResult> IsMovieFauvorite([FromQuery] int movieId, string userId) => Ok(await accountsService.IsMovieFauvorite(movieId, userId));
		

		[AllowAnonymous]
		[HttpPost("user/register")]
		public async Task<IActionResult> UserRegister([FromBody] RegisterUserModel model)
		{
			await accountsService.RegisterUserAsync(model);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost("admin/register")]
		public async Task<IActionResult> AdminRegister([FromBody] RegisterUserModel model)
		{
			await accountsService.RegisterAdminAsync(model);
			return Ok();
		}

		[HttpPost("addremovefavourite")]
		public async Task<IActionResult> AddRemoveFavourite([FromBody] FavouriteRequestModel model) => Ok(await accountsService.AddRemoveFavourite(model.Email, model.MovieId));
		

		[AllowAnonymous]
		[HttpPost("login")]
		public async Task<IActionResult> Login([FromBody] AuthRequest model) => Ok(await accountsService.LoginAsync(model));
		

		[HttpPost("logout")]
		public async Task<IActionResult> Logout([FromBody] LogoutModel token)
		{
			await accountsService.LogoutAsync(token.Token);
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
		public async Task<IActionResult> RefreshTokens([FromBody] AuthResponse tokens ) => Ok(await accountsService.RefreshTokensAsync(tokens));


		[HttpPut("edit")]
		public async Task<IActionResult> Edit([FromForm] EditUserModel user) => Ok(await accountsService.EditAsync(user));
		

		[HttpPut("setpremium")]
		public async Task<IActionResult> SetUserPremium([FromQuery] string email , int premiumId,int days) => Ok(await accountsService.SetPremiumAsync(email, premiumId, days));


		[HttpDelete("delete")]
		public async Task<IActionResult> Delete([FromQuery]string email)
		{
			await accountsService.Delete(email);
			return Ok();
		}


	}
}
