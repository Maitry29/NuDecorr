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
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

       
        public void Update(Category obj)
        {
           _db.categories.Update(obj);
        }
    }
}
