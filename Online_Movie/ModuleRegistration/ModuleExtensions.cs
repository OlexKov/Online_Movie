using BusinessLogic.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Online_Movie.ModuleRegistration
{
	public static class ModuleExtensions
	{

		public static IServiceCollection RegisterModules(this IServiceCollection services, IConfiguration configuration)
		{
			var modules = DiscoverModules();
			foreach (var module in modules)
				module.RegisterModule(services, configuration);
			return services;
		}


		private static IEnumerable<IModule> DiscoverModules()
		{
			List<Type> types = new();
			types.AddRange(Assembly.Load("BusinessLogic").GetTypes());
			types.AddRange(Assembly.Load("Online_Movie").GetTypes());
			types.AddRange(Assembly.Load("DataAccess").GetTypes());
			return types.Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
				.Select(Activator.CreateInstance)
				.Cast<IModule>();
		}
	}
}

