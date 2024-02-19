using DataAccess.Data.Entities;
using DataAccess.Data.Entities.EntitiesConfigs;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;



namespace DataAccess.Data
{
    internal class OnlineMovieDBContext : IdentityDbContext<User>
	{
		public OnlineMovieDBContext(DbContextOptions options) : base(options) 
		{
			Database.EnsureDeleted();
			Database.EnsureCreated();
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration<Country>(new CountryConfig());
			modelBuilder.ApplyConfiguration<Genre>(new GenreConfig());
			modelBuilder.ApplyConfiguration<Staf>(new StafConfig());
			modelBuilder.ApplyConfiguration<Image>(new ImageConfig());
			modelBuilder.ApplyConfiguration<Movie>(new MovieConfig());
			modelBuilder.ApplyConfiguration<StafRole>(new RoleConfig());
			modelBuilder.ApplyConfiguration<StafMovie>(new StafMovieConfig());
			modelBuilder.ApplyConfiguration<MovieGenre>(new MovieGenreConfig());
			modelBuilder.ApplyConfiguration<MovieImage>(new MovieImageConfig());
			modelBuilder.ApplyConfiguration<UserMovie>(new UserMovieConfig());
			modelBuilder.ApplyConfiguration<Quality>(new QualityConfig());
			DefaultUsers.Initialize(modelBuilder);
			DefaultData.Initialize(modelBuilder);

		}

		//public DbSet<Country> Countries { get; set; }

		//public DbSet<StafRole> StafRoles { get; set; }

		//public DbSet<Genre> Genres { get; set; }

		//public DbSet<Quality> Qualities { get; set; }

		//public DbSet<Staf> Stafs { get; set; }

		//public DbSet<Image> Images { get; set; }

		//public DbSet<Movie> Movies { get; set; }

		//public DbSet<StafMovie> StafMovies { get; set; }

		//public DbSet<UserMovie> UserMovies { get; set; }

		//public DbSet<MovieImage> MovieImages { get; set; }

		//public DbSet<MovieGenre> MovieGenres { get; set; }
	}
}
