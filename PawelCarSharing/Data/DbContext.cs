using Microsoft.EntityFrameworkCore;
using PawelCarSharing.Models;

namespace PawelCarSharing.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Rental> Rentals { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguracja mapowania dla modelu Car
            modelBuilder.Entity<Car>()
                .HasKey(c => c.Id);

            // Konfiguracja mapowania dla modelu User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            // Konfiguracja mapowania dla modelu Rental
            modelBuilder.Entity<Rental>()
                .HasKey(r => r.Id);

            // Dodatkowe konfiguracje dla relacji lub właściwości

            base.OnModelCreating(modelBuilder);
        }
    }
}
