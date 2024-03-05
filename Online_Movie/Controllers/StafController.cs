using BusinessLogic.Helpers;
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
	public class StafController : ControllerBase
	{
		private readonly IStafService stafService;

		public StafController(IStafService stafService)
		{
			this.stafService = stafService;
		}

		[AllowAnonymous]
		[HttpGet]
		public async Task<IActionResult> GetAll() => Ok(await stafService.GetAllAsync());

		[AllowAnonymous]
		[HttpGet("{id:int}")]
		public async Task<IActionResult> Get([FromRoute]int id) =>Ok(await stafService.GetAsync(id));

		[Authorize(Roles = Roles.Admin)]
		[HttpPut]
		public async Task<IActionResult> Update([FromForm] StafModel staf)
		{
			await stafService.UpdateAsync(staf);
			return Ok();
		}

		[Authorize(Roles = Roles.Admin)]
		[HttpPost]
		public async Task<IActionResult> Create([FromForm] StafModel staf)
		{
			await stafService.CreateAsync(staf);
			return Ok();
		}

		[Authorize(Roles = Roles.Admin)]
		[HttpDelete("{id:int}")]
		public async Task<IActionResult> Delete([FromRoute]int id)
		{
			await stafService.DeleteAsync(id);
			return Ok();
		}
		
	}
}
