using BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Online_Movie
{
	public class WebApiServices : IModule
	{
		public IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
		{
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});
			return services;
		}
	}
}
