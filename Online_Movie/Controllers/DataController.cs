using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Online_Movie.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DataController : ControllerBase
	{
		private readonly IDataService dataService;

		public DataController(IDataService dataService)
		{
			this.dataService = dataService;
		}
		[AllowAnonymous]
		[HttpGet("getcountries")]
		public async Task<IActionResult> GetAllCountries()
		{
			return Ok(await dataService.GetAllCountriesAsync());
		}
		[AllowAnonymous]
		[HttpGet("getroles")]
		public async Task<IActionResult> GetAllRoles()
		{
			return Ok(await dataService.GetAllRolesAsync());
		}

		[AllowAnonymous]
		[HttpGet("getgenres")]
		public async Task<IActionResult> GetAllGenres()
		{
			return Ok(await dataService.GetAllGenresAsync());
		}

		[AllowAnonymous]
		[HttpGet("getqualities")]
		public async Task<IActionResult> GetAllQualities()
		{
			return Ok(await dataService.GetAllQualitiesAsync());
		}

		[AllowAnonymous]
		[HttpGet("getpremiums")]
		public async Task<IActionResult> GetAllPremiums()
		{
			return Ok(await dataService.GetAllPremiumsAsync());
		}
	}
}
