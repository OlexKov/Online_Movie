using DataAccess.Data.Entities;
using DataAccess.Data.Entities.EntitiesConfigs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;



namespace DataAccess.Data
{
    internal class OnlineMovieDBContext : IdentityDbContext<User>
	{
		public OnlineMovieDBContext(DbContextOptions options) : base(options) 
		{
			//Database.EnsureDeleted();
			//Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			DefaultUsers.Initialize(modelBuilder);
			DefaultData.Initialize(modelBuilder);

		}
	}
}
