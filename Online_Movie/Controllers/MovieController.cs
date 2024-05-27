using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.ModelDto;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Printing;

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
		[HttpGet("getall")]
		public async Task<IActionResult> GetAll()
		{
			return Ok(await movieService.GetAllAsync());
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("getmovies/withnotapproved/{pageIndex:int}/{pageSize:int}")]
		public async Task<IActionResult> GetMoviesWithNotApprovedFeedbacks([FromRoute] int pageIndex, int pageSize) => Ok(await movieService.GetMoviesWithNotApprovedFeedbacksAsync(pageIndex, pageSize));

		[AllowAnonymous]
		//[Authorize(Roles = "Admin")]
		[HttpGet("get/notapproved/count")]
		public async Task<IActionResult> GetNotApprovedFeedbacksCount() => Ok(await movieService.GetNotApprovedFeedbacksCount());

		[AllowAnonymous]
		[HttpGet("get/{id:int}")]
		public async Task<IActionResult> Get([FromRoute] int id) => Ok(await movieService.GetByIdAsync(id));

		[AllowAnonymous]
		[HttpGet("gettop")]
		public async Task<IActionResult> GetTop([FromQuery] int count)
		{
			var topMovies = await movieService.GetTopByRatingAsync(count);
			return Ok(topMovies);
		}

		[AllowAnonymous]
		[HttpGet("getscreens/{id:int}")]
		public async Task<IActionResult> GetScreens([FromRoute] int id)
		{
			return Ok(await movieService.GetScreensAsync(id));
		}

		[AllowAnonymous]
		[HttpGet("getstafs/{id:int}")]
		public async Task<IActionResult> GetStafs([FromRoute] int id)
		{
			return Ok(await movieService.GetStafAsync(id));
		}

		[AllowAnonymous]
		[HttpGet("getfeedbacks/{id:int}/{pageIndex:int}/{pageSize:int}")]
		public async Task<IActionResult> GetFeedbacks([FromRoute] int id ,int pageIndex,int pageSize) => Ok(await movieService.GetFeedbacksAsync(id, true, pageIndex, pageSize));


		[Authorize(Roles = "Admin")]
		[HttpGet("getfeedbacks/notapproved/{id:int}/{pageIndex:int}/{pageSize:int}")]
		public async Task<IActionResult> GetNotApprovedFeedbacks([FromRoute] int id, int pageIndex, int pageSize) => Ok(await movieService.GetFeedbacksAsync(id, false, pageIndex, pageSize));

		[AllowAnonymous]
		[HttpGet("hasfeedback")]
		public async Task<IActionResult> HasFeedback([FromQuery] int movieId, string userId) => Ok(await movieService.HasFeedbackAsync(movieId, userId));

		[AllowAnonymous]
		[HttpGet("getrating/{id:int}")]
		public async Task<IActionResult> GetRating([FromRoute] int id)
		{
			return Ok(await movieService.GetRatingAsync(id));
		}

		[AllowAnonymous]
		[HttpGet("getgenres/{id:int}")]
		public async Task<IActionResult> GetGenres([FromRoute] int id)
		{
			return Ok(await movieService.GetGenresAsync(id));
		}

		[AllowAnonymous]
		[HttpPost("find")]
		public async Task<IActionResult> Find([FromForm] MovieFindFilterModel movieFilter)
		{
			return Ok(await movieService.FindAsync(movieFilter));
		}

		[Authorize(Roles = "Admin")]
		[HttpPost("create")]
		public async Task<IActionResult> Create([FromForm] MovieModel movie)
		{
			await movieService.CreateAsync(movie);
			return Ok();
		}

		[AllowAnonymous]
		[HttpPost("paginatefilter")]
		public async Task<IActionResult> GetFilteredWithPagination([FromBody] FilteredPaginationModel model) => Ok(await movieService.GetMovieFilteredPaginationAsync(model));

		[Authorize(Roles = "User")]
		[HttpPost("addfeedback")]
		public async Task<IActionResult> AddFeedback([FromForm] FeedbackCreationModel model)
		{
			await movieService.AddFeedbackAsync(model);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpPut("update")]
		public async Task<IActionResult> Update([FromForm] MovieModel movie)
		{
			await movieService.UpdateAsync(movie);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpPut("approvefeedback/{feedbackId:int}")]
		public async Task<IActionResult> ApproveFeedback([FromRoute] int feedbackId)
		{
			await movieService.ApproveFeedbackAsync(feedbackId);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("delete/{id:int}")]
		public async Task<IActionResult> Delete([FromRoute] int id)
		{
			await movieService.DeleteAsync(id);
			return Ok();
		}

		[Authorize(Roles = "Admin")]
		[HttpDelete("deletefeedback/{feedbackId:int}")]
		public async Task<IActionResult> DeleteFeedback([FromRoute] int feedbackId)
		{
			await movieService.DeleteFeedbackAsync(feedbackId);
			return Ok();
		}

	}
}
