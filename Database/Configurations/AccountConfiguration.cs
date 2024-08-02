using Book_rew.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book_rew.Database.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Accounts");
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id)
                .IsRequired()
                .ValueGeneratedNever();
            builder.Property(i => i.UserName)
                .IsRequired();
            builder.Property(i => i.Password)
                .IsRequired();
            builder.Property(i => i.PasswordSalt)
                .IsRequired();
            builder.Property(i => i.Role)
                .IsRequired();
        }
    }
}
