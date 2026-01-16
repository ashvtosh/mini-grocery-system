using GroceryBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace GroceryBackend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding Data as requested
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Apple", Price = 1.50m, Stock = 100 },
                new Product { Id = 2, Name = "Bread", Price = 2.00m, Stock = 50 },
                new Product { Id = 3, Name = "Milk", Price = 3.50m, Stock = 20 }
            );
        }
    }
}