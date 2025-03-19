using UrbanNest.DataAccess.Data;
using UrbanNest.DataAccess.Repository.IRepository;
using UrbanNest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UrbanNest.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Product obj)
        {
            var productFromDb = _db.products.FirstOrDefault(p => p.ID == obj.ID);

            if (productFromDb != null)
            {
                productFromDb.Title = obj.Title;
                productFromDb.Description = obj.Description;
                productFromDb.Price = obj.Price;
                productFromDb.CategoryId = obj.CategoryId;

                if (!string.IsNullOrEmpty(obj.ImageURL))
                {
                    productFromDb.ImageURL = obj.ImageURL; // Update Image URL only when a new image is uploaded
                }

                _db.Entry(productFromDb).State = EntityState.Modified; // ✅ Mark entity as modified
            }
        }



    }
}
    


    

