using BusinessLogic.Data.Entities;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DataAccess
{
	public class DataAccessServices : IModule
	{
		
		public IServiceCollection RegisterModule(IServiceCollection services,IConfiguration configuration)
		{
			services.AddDbContext<OnlineMovieDBContext>(opts =>
			opts.UseSqlServer(configuration.GetConnectionString("LocalDb")!));

			services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

			services.AddIdentity<User, IdentityRole>(options =>
			{
				options.SignIn.RequireConfirmedAccount = false;
			})
			   .AddDefaultTokenProviders()
			   .AddEntityFrameworkStores<OnlineMovieDBContext>();
			return services;
		}
    }
}
