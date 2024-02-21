using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class MovieConfig : IEntityTypeConfiguration<Movie>
	{
		public void Configure(EntityTypeBuilder<Movie> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasMaxLength(256);
			builder.Property(x => x.OriginalName).HasMaxLength(256);
			builder.Property(x => x.Poster).HasDefaultValue("noposter.jpeg");
			builder.HasOne(x => x.Quality)
				   .WithMany(x => x.Movies)
				   .HasForeignKey(x=>x.QualityId);
			builder.HasOne(x => x.Country)
				   .WithMany(x => x.Movies)
				   .HasForeignKey(x => x.CountryId);
			builder.HasOne(x => x.Premium)
				   .WithMany(x => x.Movies)
				   .HasForeignKey(x=>x.PremiumId);
			builder.ToTable(t => t.HasCheckConstraint("Name_check", "[Name] <> ''"));
			builder.ToTable(t => t.HasCheckConstraint("OriginalName_check", "[OriginalName] <> ''"));
			builder.ToTable(t => t.HasCheckConstraint("MovieUrl_check", "[MovieUrl] <> ''"));
			
		}
	}
}
