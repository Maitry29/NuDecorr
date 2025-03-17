using Microsoft.EntityFrameworkCore;
using UrbanNest.Models;

namespace UrbanNest.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { ID = 1, Name = "Table", DisplayOrder = 1 },
               new Category { ID = 2, Name = "Chair", DisplayOrder = 2 },
               new Category { ID = 3, Name = "Sofa", DisplayOrder = 1 },
               new Category { ID = 4, Name = "Lamp", DisplayOrder = 3 },
               new Category { ID = 5, Name = "Bed", DisplayOrder = 1 }
            );

            modelBuilder.Entity<Product>().HasData(
           new Product
           {
               ID = 1,
               Title = "Wooden Dining Table",
               Description = "A high-quality wooden dining table with a modern design.",
               Price = 19999.99m,
               CategoryId = 1,
               ImageURL = "https://example.com/images/dining-table.jpg"
           },
           new Product
           {
               ID = 2,
               Title = "Luxury Sofa Set",
               Description = "A comfortable and elegant sofa set for your living room.",
               Price = 29999.99m,
              CategoryId = 2,
               ImageURL = "https://example.com/images/sofa-set.jpg"
           },
           new Product
           {
               ID = 3,
               Title = "Office Chair",
               Description = "Ergonomic office chair with adjustable height and back support.",
               Price = 7999.99m,
               CategoryId = 3,
               ImageURL = "https://example.com/images/office-chair.jpg"
           },
           new Product
           {
               ID = 4,
               Title = "Lamp",
               Description = "Ergonomic lamp with adjustable height.",
               Price = 7999.99m,
               CategoryId = 4,
               ImageURL = "https://example.com/images/office-chair.jpg"
           },
           new Product
           {
               ID = 5,
               Title = "Bed",
               Description = "Comfortable bed with back support.",
               Price = 7999.99m,
               CategoryId = 3,
               ImageURL = "https://example.com/images/office-chair.jpg"
           }
             );
        }
    }
}
