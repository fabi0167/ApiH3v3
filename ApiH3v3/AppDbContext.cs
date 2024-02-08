using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies; // Add this namespace

namespace ApiH3v3
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet properties for your entity classes
        public DbSet<Car> Cars { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<FuelType> FuelTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        public DbSet<CarFuelType> CarFuelTypes { get; set; }
        // Add DbSet properties for other entity classes as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define keyless entity type for CarFuelType and CarManufacturer
            modelBuilder.Entity<CarFuelType>().HasNoKey();
            modelBuilder.Entity<CarManufacturer>().HasNoKey();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            // Configure the DbContext to use lazy loading proxies
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
