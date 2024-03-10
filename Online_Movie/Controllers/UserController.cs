using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Online_Movie.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService userService;
		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		[HttpPost("addremovefavourite/{id:int}")]
		public async Task<IActionResult> AddRemoveFavourite([FromRoute] int id)
		{
			await userService.AddRemoveFavourite(User.Identity!.Name!, id);
			return Ok();
		}

		[HttpGet("getfavourits")]
		public async Task<IActionResult> GetFavourits() => Ok(await userService.GetFavourits(User.Identity!.Name!));

		[HttpGet("getpremium")]
		public async Task<IActionResult> GetPremium()
		{
			var prem = await userService.GetPremium(User.Identity!.Name!);
			return Ok(prem);
		}
	}
}
