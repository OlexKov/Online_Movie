using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Entities;

namespace DataAccess.Data.EntitiesConfigs
{
	internal class RefreshTokenConfig : IEntityTypeConfiguration<RefreshToken>
	{
		public void Configure(EntityTypeBuilder<RefreshToken> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Token).HasMaxLength(256);
			builder.Property(x => x.CreationDate);
			builder.HasOne(x => x.User)
				   .WithMany(x => x.RefreshTokens)
				   .HasForeignKey(x => x.UserId)
				   .OnDelete(DeleteBehavior.Cascade);
			builder.ToTable(t => t.HasCheckConstraint("Token_check", "[Token] <> ''"));
		}
	}
}
