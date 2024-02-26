using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic
{
	public class BusinessLogicServices : IModule
	{
		public IServiceCollection RegisterModule(IServiceCollection services, IConfiguration configuration)
		{
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			//services.AddSingleton(provider => new MapperConfiguration(cfg =>
			//{
			//	cfg.AddProfile(new StaftProfile(provider.CreateScope().ServiceProvider.GetService<IFileService>()));

			//}).CreateMapper());

			//services.AddFluentValidationAutoValidation();
			// enable client-side validation
			//services.AddFluentValidationClientsideAdapters();
			// Load an assembly reference rather than using a marker type.
			services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

			services.AddScoped<IStafService, StafService>();

			services.AddScoped<IImageService, ImageService>();

			services.AddScoped<IMovieService, MovieService>();

			return services;
		}
	}
}
