using Microsoft.EntityFrameworkCore;
using RestaurantService.Domain.Entities;
using System.Reflection;

namespace RestaurantService.Infrastructure.Persistence
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options) { }
        public DbSet<Restaurant> Restaurants { get; set; } = null!;
        public DbSet<MenuCategory> MenuCategories { get; set; } = null!;
        public DbSet<MenuItem> MenuItems { get; set; } = null!;
        public DbSet<Address> Addresses { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the relationships and constraints here if needed
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            // Restaurant <-> MenuCategory (One-to-Many)
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.MenuCategories)
                .WithOne(mc => mc.Restaurant) // Navigation property back to Restaurant
                .HasForeignKey(mc => mc.RestaurantId)
                .OnDelete(DeleteBehavior.Cascade); // Or Restrict, depending on business rules

            // MenuCategory <-> MenuItem (One-to-Many)
            modelBuilder.Entity<MenuCategory>()
                .HasMany(mc => mc.MenuItems)
                .WithOne(mi => mi.MenuCategory) // Navigation property back to MenuCategory
                .HasForeignKey(mi => mi.MenuCategoryId)
                .OnDelete(DeleteBehavior.Cascade); // Or Restrict

            // Configure Enum to string conversion for Restaurant Status
            modelBuilder.Entity<Restaurant>()
                .Property(e => e.Status)
                .HasConversion<string>()
                .HasMaxLength(50); // Define max length for string storage
        }
    }
}
