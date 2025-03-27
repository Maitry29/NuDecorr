using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UrbanNest.Utility;
using System.Security.Claims;
using UrbanNest.DataAccess.Repository;
using UrbanNest.DataAccess.Repository.IRepository;
using UrbanNest.Models;

namespace UrbanNest.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class FurnitureController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public int productId { get; private set; }

        public FurnitureController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            IEnumerable<Product> productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return View(productList);
        }

        public IActionResult Details(int productId)
        {
            ShoppingCart cart = new()
            {
                Product = _unitOfWork.Product.Get(u => u.ID == productId, includeProperties: "Category,ProductImages"),
                Count = 1,
                ProductId = productId
            };
            return View(cart);
    
        }

        [HttpPost]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingCart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            shoppingCart.ApplicationUserId = userId;

            ShoppingCart cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.ApplicationUserId == userId &&
            u.ProductId == shoppingCart.ProductId);

            if (cartFromDb != null)
            {
                //shopping cart exists
                cartFromDb.Count += shoppingCart.Count;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
                //        _unitOfWork.Save();
            }
            else
            {
                //add cart record
                _unitOfWork.ShoppingCart.Add(shoppingCart);
                //        _unitOfWork.Save();
                //        HttpContext.Session.SetInt32(SD.SessionCart,
                //        _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId).Count());
            }
            TempData["success"] = "Cart updated successfully";
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public IActionResult Details(ShoppingCart shoppingCart)
        //{
        //    ShoppingCart cart = new()
        //    {
        //        Product = _unitOfWork.Product.Get(u => u.ID == productId, includeProperties: "Category,ProductImages"),
        //        Count = 1,
        //        ProductId = productId
        //    };
        //    return View(cart);

        //    //Product product = _unitOfWork.Product.Get(u => u.ID == productId, includeProperties: "Category");
        //    //return View(product);
        //}   
    }
    }

