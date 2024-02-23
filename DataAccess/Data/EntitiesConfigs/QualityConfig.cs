using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Data.Entities;


namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class QualityConfig : IEntityTypeConfiguration<Quality>
	{
		public void Configure(EntityTypeBuilder<Quality> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasMaxLength(256);
			builder.HasIndex(x => x.Name);
			builder.ToTable(t => t.HasCheckConstraint("Name_check", "[Name] <> ''"));
		}
	}
}
