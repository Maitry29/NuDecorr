using Microsoft.AspNetCore.Mvc;
using NuDecorr.Data;
using NuDecorr.Models;

namespace NuDecorr.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.categories.ToList();
            return View(objCategoryList);
        }
    }
}
