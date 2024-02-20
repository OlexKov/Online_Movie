using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class PremiumConfig : IEntityTypeConfiguration<Premium>
	{
		public void Configure(EntityTypeBuilder<Premium> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasMaxLength(256);
			builder.HasIndex(x => x.Name);
			builder.HasMany(x => x.Users)
				   .WithOne(x => x.Premium)
				   .HasForeignKey(x => x.PremiumId);
			builder.ToTable(t => t.HasCheckConstraint("Name_check", "[Name] <> ''"));
		}
	}
}
