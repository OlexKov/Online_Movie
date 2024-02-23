using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Data.Entities;

namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class StafMovieConfig : IEntityTypeConfiguration<StafMovie>
	{
		public void Configure(EntityTypeBuilder<StafMovie> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Movie)
				   .WithMany(x => x.StafMovies)
				   .HasForeignKey(x=>x.MovieId)
				   .OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(x => x.Staf)
				   .WithMany(x => x.StafMovies)
				   .HasForeignKey(x => x.StafId)
			       .OnDelete(DeleteBehavior.NoAction);

		}
	}
}
