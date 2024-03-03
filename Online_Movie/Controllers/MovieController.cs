using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Online_Movie.Controllers
{
	[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

		[Authorize(Roles = "Admin")]
		[HttpPut]
		public async Task<IActionResult> Update([FromForm] MovieModel movie)
		{
			await movieService.UpdateAsync(movie);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpPost]
		public async Task<IActionResult> Create([FromForm] MovieModel movie)
		{
			await movieService.CreateAsync(movie);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			await movieService.DeleteAsync(id);
			return Ok();
		}

	}
}
