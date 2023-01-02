using CurrencyManager.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyManager.Data.Configutation
{
    public class CurrencyManagerDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CurrencyManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Users");
                entityTypeBuilder.HasKey(u => u.Id);
                entityTypeBuilder.Property(u => u.CreationDate);
                entityTypeBuilder.Property(u => u.Login);
                entityTypeBuilder.Property(u => u.Password);
                entityTypeBuilder.Property(u => u.EmailAddress);
                entityTypeBuilder.Property(u => u.Balance);
            });
        }
    }
}
