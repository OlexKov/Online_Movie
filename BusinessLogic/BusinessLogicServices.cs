using BusinessLogic.Helpers;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;

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

			services.AddScoped<IAccountsService, AccountsService>();

			services.AddMailKit(optionBuilder =>
			{
				MailSettings? settings = configuration.GetSection("UkrNetMailSettings").Get<MailSettings>();
				if (settings == null) throw new HttpException("Error mail servise configuration",System.Net.HttpStatusCode.InternalServerError);
				optionBuilder.UseMailKit(new MailKitOptions()
				{
					Server = settings.Server,
					Port = settings.Port,
					SenderName = settings.SenderName,
					SenderEmail = settings.SenderEmail,
					Account = settings.Account,
					Password = settings.Password,
					Security = true
				});
			});

			return services;
		}
	}
}
