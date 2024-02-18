using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class MovieImageConfig : IEntityTypeConfiguration<MovieImage>
	{
		public void Configure(EntityTypeBuilder<MovieImage> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.Movie)
				   .WithMany(x => x.MovieImages)
				   .HasForeignKey(x => x.MovieId)
				   .OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(x => x.Image)
				   .WithMany(x => x.MovieImages)
				   .HasForeignKey(x => x.ImageId)
				   .OnDelete(DeleteBehavior.NoAction); 
		}
	}
}
