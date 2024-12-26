using Microsoft.EntityFrameworkCore;
using NuDecorr.Models;

namespace NuDecorr.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options) : base(options)
        {
            
        }

        public DbSet<Category> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
               new Category { Id = 1, Name = "Table", DisplayOrder = 1 },
               new Category { Id = 2, Name = "Chair", DisplayOrder = 2 },
               new Category { Id = 3, Name = "Sofa", DisplayOrder = 1 },
               new Category { Id = 4, Name = "Lamp", DisplayOrder = 3 },
               new Category { Id = 5, Name = "Bed", DisplayOrder = 1 }
            );
        }
    }
}
