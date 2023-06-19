using Microsoft.EntityFrameworkCore;
using PawelCarSharing.Models;

namespace PawelCarSharing.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .ToTable("Car");
            modelBuilder.Entity<Car>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Account>()
                .ToTable("Account");
            modelBuilder.Entity<Account>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Rental>()
                .ToTable("Rental");
            modelBuilder.Entity<Rental>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<AccountRental>()
                .ToTable("AccountRental");
            modelBuilder.Entity<AccountRental>()
                .HasKey(ra => new { ra.RentalId, ra.AccountId });

            modelBuilder.Entity<AccountRental>()
                .HasOne(ra => ra.Rental)
                .WithMany(r => r.Accounts)
                .HasForeignKey(ra => ra.RentalId);

            modelBuilder.Entity<AccountRental>()
                .HasOne(ra => ra.Account)
                .WithMany(a => a.Rentals)
                .HasForeignKey(ra => ra.AccountId);

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CarId);
        }
    }
}