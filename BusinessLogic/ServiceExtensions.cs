using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLogic
{
	public static class ServiceExtensions
	{
		public static void AddAutoMapper(this IServiceCollection services)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			//services.AddSingleton(provider => new MapperConfiguration(cfg =>
			//{
			//	cfg.AddProfile(new ProductProfile(provider.CreateScope().ServiceProvider.GetService<IFileService>()));

			//}).CreateMapper());
		}

		public static void AddFluentValidator(this IServiceCollection services)
		{
			//services.AddFluentValidationAutoValidation();
			// enable client-side validation
			//services.AddFluentValidationClientsideAdapters();
			// Load an assembly reference rather than using a marker type.
			services.Configure<ApiBehaviorOptions>(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});
			services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
		}

		public static void AddCustomServices(this IServiceCollection services)
		{
			services.AddScoped<IStafService, StafService>();
			services.AddScoped<IImageService, ImageService>();
			services.AddScoped<IMovieService, MovieService>();
		}
	}
}

