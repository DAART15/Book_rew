using Book_rew.Database.Configurations;
using Book_rew.Models;
using Microsoft.EntityFrameworkCore;

namespace Book_rew.Database
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books  { get; set; }
        public DbSet<Review> Reviews  { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new AccountConfiguration());
            modelBuilder.ApplyConfiguration(new ReviewConfiguration());
            
        }
    }
}
