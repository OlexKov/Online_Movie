using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Online_Movie.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MovieController : ControllerBase
	{
		private readonly IMovieService movieService;

		public MovieController(IMovieService movieService)
        {
			this.movieService = movieService;
			
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await movieService.GetAllAsync());
		}
		
		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id) => Ok(await movieService.GetByIdAsync(id));

		[HttpPut]
		public async Task<IActionResult> Update([FromForm] MovieModel movie)
		{
			//await stafService.UpdateAsync(staf);
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] MovieModel movie)
		{
			//await stafService.CreateAsync(staf);
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
