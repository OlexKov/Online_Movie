using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Online_Movie.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles = Roles.Admin)]
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly IMovieService movieService;

		public MovieController(IMovieService movieService)
        {
			this.movieService = movieService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await movieService.GetAllAsync());
		}

		[AllowAnonymous]
		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id) => Ok(await movieService.GetByIdAsync(id));

		[HttpPut]
		public async Task<IActionResult> Update([FromForm] MovieModel movie)
		{
			await movieService.UpdateAsync(movie);
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] MovieModel movie)
		{
			await movieService.CreateAsync(movie);
			return Ok();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			await movieService.DeleteAsync(id);
			return Ok();
		}

	}
}
