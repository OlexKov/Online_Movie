using BusinessLogic.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace BusinessLogic.ModuleRegistration
{
	public static class ModuleExtensions
	{
		static readonly List<IModule> registeredModules = new ();

		public static IServiceCollection RegisterModules(this IServiceCollection services, IConfiguration configuration)
		{
			var modules = DiscoverModules();
			foreach (var module in modules)
			{
				module.RegisterModule(services, configuration);
				registeredModules.Add(module);
			}
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

