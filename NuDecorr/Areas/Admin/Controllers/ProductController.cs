using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuDecorr.DataAccess.Data;
using NuDecorr.DataAccess.Repository.IRepository;
using NuDecorr.Models;
using System.Collections.Generic;

namespace NuDecorr.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
          //  Console.WriteLine("Index method hit");
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
             // return View(objProductList);
             return View("~/Areas/Admin/Views/Product/Index.cshtml", objProductList);

        }


        public IActionResult Create()
        {
            //ViewBag.CatagoryList = _unitOfWork.Category.GetAll()
            //    .Select(u => new SelectListItem
            //    {
            //        Text = u.Name,
            //        Value = u.CategoryID.ToString()
            //    })
            //    .ToList();

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product obj)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine("Product is being added!"); // Debugging
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product Created successfully";
                return RedirectToAction("Index");
            }
            Console.WriteLine("ModelState is invalid"); // Debugging
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? productFromDb = _unitOfWork.Product.Get(u => u.ProductID == id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }

            return View(obj); // ✅ Pass back the model if ModelState is invalid
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.ProductID == id);
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(u => u.ProductID == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product Deleted successfully";
            return RedirectToAction("Index");
        }



    }
}
