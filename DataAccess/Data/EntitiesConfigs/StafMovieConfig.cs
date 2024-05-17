using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Data.Entities;

namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class StafMovieConfig : IEntityTypeConfiguration<StafMovieRole>
	{
		public void Configure(EntityTypeBuilder<StafMovieRole> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Movie)
				   .WithMany(x => x.StafMovieRoles)
				   .HasForeignKey(x=>x.MovieId)
				   .OnDelete(DeleteBehavior.Cascade);
			builder.HasOne(x => x.Staf)
				   .WithMany(x => x.StafMovieRoles)
				   .HasForeignKey(x => x.StafId)
			       .OnDelete(DeleteBehavior.ClientCascade);
			builder.HasOne(x => x.StafRole)
				   .WithMany(x => x.StafMovieRoles)
				   .HasForeignKey(x => x.StafRoleId)
				   .OnDelete(DeleteBehavior.ClientCascade);

		}
	}
}
