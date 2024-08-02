using Book_rew.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_rew.Database.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("Reviews");
            builder.HasKey(r => r.Id);
            builder.Property(r => r.Id)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(r => r.BookId)
                .IsRequired();
            builder.Property(r =>r.ReviewerName)
                .IsRequired();
            builder.Property(r => r.Rating)
                .IsRequired();
            builder.Property(r =>r.Comment)
                .IsRequired();
            builder.HasData(
                new Review(1, 1, "Ramas", 5, "One of the best")
                );
        }
    }
}
