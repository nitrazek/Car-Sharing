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

            // Konfiguracja mapowania dla modelu Car
            modelBuilder.Entity<Car>()
                .ToTable("Car");
            modelBuilder.Entity<Car>()
                .HasKey(c => c.Id);

            // Konfiguracja mapowania dla modelu Account
            modelBuilder.Entity<Account>()
                .ToTable("Account");
            modelBuilder.Entity<Account>()
                .HasKey(a => a.Id);

            // Konfiguracja mapowania dla modelu Rental
            modelBuilder.Entity<Rental>()
                .ToTable("Rental");
            modelBuilder.Entity<Rental>()
                .HasKey(r => r.Id);

            modelBuilder.Entity<Rental>()
                .HasOne(x => x.Car)
                .WithMany(x => x.Rentals)
                .HasForeignKey(x => x.CarId);
        }
    }
}
