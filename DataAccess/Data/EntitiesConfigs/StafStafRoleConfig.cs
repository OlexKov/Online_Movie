using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.Data.Entities;

namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class StafStafRoleConfig : IEntityTypeConfiguration<StafStafRole>
	{
		public void Configure(EntityTypeBuilder<StafStafRole> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.StafRole)
				   .WithMany(x => x.StafStafRoles)
				   .HasForeignKey(x => x.StafRoleId)
				   .OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(x => x.Staf)
				   .WithMany(x => x.StafStafRoles)
				   .HasForeignKey(x => x.StafId)
			       .OnDelete(DeleteBehavior.NoAction);

		}
	}
}
