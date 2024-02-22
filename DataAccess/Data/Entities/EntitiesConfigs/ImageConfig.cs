using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class ImageConfig : IEntityTypeConfiguration<Image>
	{
		public void Configure(EntityTypeBuilder<Image> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasMaxLength(256);
			builder.HasIndex(x => x.Name);
			builder.HasOne(x => x.Movie)
				   .WithMany(x => x.ScreenShots)
				   .HasForeignKey(x=>x.MovieId)
				   .OnDelete(DeleteBehavior.Cascade);
			builder.ToTable(t => t.HasCheckConstraint("Name_check", "[Name] <> ''"));
		}
	}
}
