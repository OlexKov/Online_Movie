using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class StafConfig: IEntityTypeConfiguration<Staf>
	{
		public void Configure(EntityTypeBuilder<Staf> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name)
				   .HasMaxLength(256);
			builder.Property(x => x.Surname)
				   .HasMaxLength(256);
			builder.Property(x=>x.ImageName)
				   .HasDefaultValue("nofoto.png");
			builder.Property(x => x.Description);
			builder.Property(x => x.ImageName)
				   .HasMaxLength(256);
			builder.HasOne(x => x.Country)
				   .WithMany(x => x.Stafs)
				   .HasForeignKey(x => x.CountryId);
			builder.HasOne(x => x.StafRole)
				   .WithMany(x => x.Stafs)
				   .HasForeignKey(x=>x.StafRoleId);
			builder.ToTable(t => t.HasCheckConstraint("Name_check", "[Name] <> ''"));
			builder.ToTable(t => t.HasCheckConstraint("Surname_check", "[Surname] <> ''"));
		}
	}
}
