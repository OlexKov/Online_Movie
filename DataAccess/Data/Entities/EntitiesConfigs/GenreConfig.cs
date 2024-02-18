using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class GenreConfig : IEntityTypeConfiguration<Genre>
	{
		public void Configure(EntityTypeBuilder<Genre> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasMaxLength(256);
			builder.HasIndex(x => x.Name);
			builder.ToTable(t => t.HasCheckConstraint("Name_check", "[Name] <> ''"));
		}
	}
}
