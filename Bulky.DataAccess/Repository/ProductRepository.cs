using NuDecorr.DataAccess.Data;
using NuDecorr.DataAccess.Repository.IRepository;
using NuDecorr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NuDecorr.DataAccess.Repository
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
            var productFromDb = _db.products.FirstOrDefault(p => p.ProductID == obj.ProductID);

            if (productFromDb != null)
            {
                productFromDb.Title = obj.Title;
                productFromDb.Description = obj.Description;
                productFromDb.Price = obj.Price;
                productFromDb.ImageURL = obj.ImageURL;
            }
        }

    }
}
