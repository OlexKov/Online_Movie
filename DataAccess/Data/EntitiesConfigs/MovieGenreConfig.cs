using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Data.Entities;

namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class MovieGenreConfig : IEntityTypeConfiguration<MovieGenre>
	{
		public void Configure(EntityTypeBuilder<MovieGenre> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Movie)
				   .WithMany(x => x.MovieGenres)
				   .HasForeignKey(x => x.MovieId)
				   .OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(x => x.Genre)
				   .WithMany(x => x.MovieGenres)
				   .HasForeignKey(x => x.GenreId)
				   .OnDelete(DeleteBehavior.NoAction);
		}
	}
}
