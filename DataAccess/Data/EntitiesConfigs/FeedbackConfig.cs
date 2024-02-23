using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Data.Entities;

namespace DataAccess.Data.Entities.EntitiesConfigs
{
	internal class FeedbackConfig : IEntityTypeConfiguration<Feedback>
	{
		public void Configure(EntityTypeBuilder<Feedback> builder)
		{
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Text).HasMaxLength(512);
			builder.Property(x => x.Rating).HasDefaultValue(0);
			builder.HasOne(x => x.Movie)
				   .WithMany(x => x.Feedbacks)
				   .HasForeignKey(x => x.MovieId)
				   .OnDelete(DeleteBehavior.NoAction);
			builder.HasOne(x => x.User)
				   .WithMany(x => x.Feedbacks)
				   .HasForeignKey(x => x.UserId)
				   .OnDelete(DeleteBehavior.NoAction);
			builder.ToTable(t => t.HasCheckConstraint("Text_check", "[Text] <> ''"));
		}
	}
}
