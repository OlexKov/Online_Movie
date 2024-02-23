using Microsoft.AspNetCore.Mvc;

namespace Online_Movie.Exstensions
{
	public static class Extensions
	{
		public static void DisableGlobalValidation(this IServiceCollection services)
		{
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});
		}
	}
}
