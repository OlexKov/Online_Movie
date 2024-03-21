using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogic.Interfaces
{
	public interface IModule
	{
		IServiceCollection RegisterModule(IServiceCollection builder,IConfiguration configuration);
	}
}
