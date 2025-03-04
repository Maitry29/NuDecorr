using Microsoft.AspNetCore.Mvc;
using NuDecorr.DataAccess.Data;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "Display order cannot sa,e as Name.");
            //}

            //if (obj.Name!= null && obj.Name.ToLower() == "test")
            //{
            //    ModelState.AddModelError(" ", "Test is an invalid value.");
            //}
            if (ModelState.IsValid)
            {
                _db.categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created successfully";
                return RedirectToAction("Index");
            }
            return View();


        }

        public IActionResult Edit(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.categories.Find(id);
           if(categoryFromDb ==null )
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDb = _db.categories.Find(id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost ,ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Category? obj = _db.categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category Deleted successfully";
            return RedirectToAction("Index");
        }
        
    }
}
