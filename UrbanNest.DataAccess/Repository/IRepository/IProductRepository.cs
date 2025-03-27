using UrbanNest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanNest.DataAccess.Repository.IRepository
{
    //public interface IProductRepository : IRepository<Product>
    //{
    //    IEnumerable<Product> GetAll(string includeProperties);
    //    void Update(Product obj);

    //}

    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}
