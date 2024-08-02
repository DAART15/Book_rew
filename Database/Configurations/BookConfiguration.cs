using Book_rew.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_rew.Database.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(b => b.Title)
                .IsRequired();
            builder.Property(b => b.Author)
                .IsRequired();
            builder.Property(b => b.ISBN)
                .IsRequired();
            builder.Property(b => b.PublishedTime)
                .IsRequired();
            builder.HasData(
                new Book(1, "Digital Fortress", "Dan Brown", "1234567890123")
                );
                
            
        }
    }
}
