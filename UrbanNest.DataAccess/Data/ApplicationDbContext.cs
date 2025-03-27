using UrbanNest.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace UrbanNest.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        public DbSet<ProductImage> productsImage { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
               new Category { ID = 1, Name = "Table", DisplayOrder = 1 },
               new Category { ID = 2, Name = "Chair", DisplayOrder = 2 },
               new Category { ID = 3, Name = "Sofa", DisplayOrder = 1 },
               new Category { ID = 4, Name = "Lamp", DisplayOrder = 3 },
               new Category { ID = 5, Name = "Bed", DisplayOrder = 1 }
            );

            modelBuilder.Entity<Company>().HasData(
               new Company
               {
                   Id = 1,
                   Name = "Decorr Solution",
                   StreetAddress = "123 Tech St",
                   City = "Tech City",
                   PostalCode = "12121",
                   State = "IL",
                   PhoneNumber = "6669990000"
               },
               new Company
               {
                   Id = 2,
                   Name = "Homely",
                   StreetAddress = "999 Vid St",
                   City = "Vid City",
                   PostalCode = "66666",
                   State = "IL",
                   PhoneNumber = "7779990000"
               },
               new Company
               {
                   Id = 3,
                   Name = "Interior Club",
                   StreetAddress = "999 Main St",
                   City = "Lala land",
                   PostalCode = "99999",
                   State = "NY",
                   PhoneNumber = "1113335555"
               }
               );

            modelBuilder.Entity<Product>().HasData(
           new Product
           {
               ID = 1,
               Title = "Wooden Dining Table",
               Description = "A high-quality wooden dining table with a modern design.",
               Price = 19999.99m,
               CategoryId = 1,
               ImageURL = "/images/products/Table.jpg"  
           },
           new Product
           {
               ID = 2,
               Title = "Luxury Sofa Set",
               Description = "A comfortable and elegant sofa set for your living room.",
               Price = 29999.99m,
              CategoryId = 2,
               ImageURL = "/images/products/Sofa.jpg"
           },
           new Product
           {
               ID = 3,
               Title = "Office Chair",
               Description = "Ergonomic office chair with adjustable height and back support.",
               Price = 7999.99m,
               CategoryId = 3,
               ImageURL = "/images/products/Chair.jpg"
           },
           new Product
           {
               ID = 4,
               Title = "Lamp",
               Description = "Ergonomic lamp with adjustable height.",
               Price = 7999.99m,
               CategoryId = 4,
               ImageURL = "/images/products/Lamp.jpg"
           },
           new Product
           {
               ID = 5,
               Title = "Bed",
               Description = "Comfortable bed with back support.",
               Price = 7999.99m,
               CategoryId = 3,
               ImageURL = "/images/products/Bed.jpg"
           }
             );
        }
    }
}
 