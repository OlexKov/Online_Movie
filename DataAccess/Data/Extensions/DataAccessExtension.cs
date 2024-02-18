using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.Data.Extensions
{
    public static class DataAccessExtension
    {
        public static void AddDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<OnlineMovieDBContext>(opts =>
                opts.UseSqlServer(connectionString));
        }
    }
}
