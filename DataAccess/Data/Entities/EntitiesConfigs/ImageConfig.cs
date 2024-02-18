using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class ImageConfig : IEntityTypeConfiguration<Image>
	{
		public void Configure(EntityTypeBuilder<Image> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Name).HasMaxLength(256);
			builder.HasIndex(x => x.Name);
			builder.ToTable(t => t.HasCheckConstraint("Name_check", "[Name] <> ''"));
		}
	}
}
