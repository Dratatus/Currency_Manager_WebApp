using CurrencyManager.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CurrencyManager.Data.Configutation
{
    public class CurrencyManagerDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PersonalInfo> PersonalInfo { get; set; }
        public virtual DbSet<Passes> Passes { get; set; }
        public virtual DbSet<ExchangeRateHistory> ExchangeRateHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=CurrencyManager;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Users");
                entityTypeBuilder.HasKey(u => u.Id);
                entityTypeBuilder.Property(u => u.CreationDate);
                entityTypeBuilder.Property(u => u.IsPremium);

                entityTypeBuilder.Property(u => u.PassesId);
                entityTypeBuilder.HasOne(u => u.Passes).WithMany().HasForeignKey(u => u.PassesId);

                entityTypeBuilder.Property(u => u.PersonalInfoId);
                entityTypeBuilder.HasOne(u => u.PersonalInfo).WithMany().HasForeignKey(u => u.PersonalInfoId);

                entityTypeBuilder.Property(u => u.ExchangeRateHistoryId);
                entityTypeBuilder.HasMany(u => u.ExchangeRateHistory).WithOne().HasForeignKey(erh => erh.UserId);

                entityTypeBuilder.Navigation(u => u.Passes).AutoInclude();
                entityTypeBuilder.Navigation(u => u.PersonalInfo).AutoInclude();
                entityTypeBuilder.Navigation(u => u.ExchangeRateHistory).AutoInclude();
            });

            modelBuilder.Entity<Passes>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("Passes");
                entityTypeBuilder.HasKey(p => p.Id);
                entityTypeBuilder.Property(p => p.CreationDate);
                entityTypeBuilder.Property(p => p.EmailAddress);
                entityTypeBuilder.Property(p => p.Password);
            });

            modelBuilder.Entity<PersonalInfo>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("PersonalInfo");
                entityTypeBuilder.HasKey(pi => pi.Id);
                entityTypeBuilder.Property(pi => pi.CreationDate);
                entityTypeBuilder.Property(pi => pi.Name);
                entityTypeBuilder.Property(pi => pi.Surname);
                entityTypeBuilder.Property(pi => pi.Age);
            });

            modelBuilder.Entity<ExchangeRateHistory>(entityTypeBuilder =>
            {
                entityTypeBuilder.ToTable("ExchangeRateHistory");
                entityTypeBuilder.HasKey(erh => erh.Id);
                entityTypeBuilder.Property(erh => erh.CreationDate);
                entityTypeBuilder.Property(erh => erh.UserId);
                entityTypeBuilder.Property(erh => erh.BoughtCurrency);
                entityTypeBuilder.Property(erh => erh.SelledCurrency);
                entityTypeBuilder.Property(erh => erh.Amount);
            });
        }
    }
}
