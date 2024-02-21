using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using BusinessLogic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Online_Movie.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StafController : ControllerBase
	{
		private readonly IStafService stafService;

		public StafController(IStafService stafService)
		{
			this.stafService = stafService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll() => Ok(await stafService.GetAllAsync());
		

		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute]int id) =>Ok(await stafService.GetAsync(id));

		[HttpPut]
		public async Task<IActionResult> Update([FromForm] StafModel staf)
		{
			await stafService.UpdateAsync(staf);
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm] StafModel staf)
		{
			await stafService.CreateAsync(staf);
			return Ok();
		}

		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute]int id)
		{
			await stafService.DeleteAsync(id);
			return Ok();
		}
		
	}
}
