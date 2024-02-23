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
	internal class UserMovieConfig : IEntityTypeConfiguration<UserMovie>
	{
		public void Configure(EntityTypeBuilder<UserMovie> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasOne(x => x.User)
				   .WithMany(x => x.UserMovies)
				   .HasForeignKey(x=>x.UserId)
				   .OnDelete(DeleteBehavior.NoAction); ;
			builder.HasOne(x => x.Movie)
				   .WithMany(x => x.UserMovies)
				   .HasForeignKey(x => x.MovieId)
				   .OnDelete(DeleteBehavior.NoAction);

		}
	}
}
