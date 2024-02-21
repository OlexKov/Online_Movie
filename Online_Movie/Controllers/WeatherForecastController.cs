using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Online_Movie.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class WeatherForecastController : ControllerBase
	{
		private readonly IStafService stafService;

		public WeatherForecastController(IStafService stafService)
		{
			this.stafService = stafService;
		}

		[HttpGet(Name = "GetWeatherForecast")] 
		public async Task<IEnumerable<StafDto>> Get() => await stafService.GetAllAsync();
		
	}
}
