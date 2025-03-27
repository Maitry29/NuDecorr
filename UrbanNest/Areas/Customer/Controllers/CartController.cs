using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UrbanNest.DataAccess.Repository.IRepository;
using UrbanNest.Models;
using UrbanNest.Models.ViewModels;
using UrbanNest.Utility;

namespace UrbanNest.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {


        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
           // ShoppingCartVM = shoppingCartVM;
        }

        //public IActionResult Index()
        //{
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

        //    ShoppingCartVM = new()
        //    {
        //        ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
        //        includeProperties: "Product")
        //    };


        //    foreach (var cart in ShoppingCartVM.ShoppingCartList)
        //    {
        //        //     cart.Price = GetPriceBasedOnQuantity(cart);
        //        //     //double price = GetPriceBasedOnQuantity(cart);
        //        //    ShoppingCartVM.OrderTotal += (cart.Price * cart.Count);
        //        ShoppingCartVM.OrderTotal += (cart.Price * cart.Count);
        //    }

        //    return View(ShoppingCartVM);
        //}
        //public IActionResult Index()
        //{
        //    var claimsIdentity = (ClaimsIdentity)User.Identity;
        //    var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;

        //    ShoppingCartVM = new()
        //    {
        //        ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
        //        includeProperties: "Product")
        //    };

        //    foreach (var cart in ShoppingCartVM.ShoppingCartList)
        //    {
        //        cart.Price = GetPriceBasedOnQuantity(cart);
        //        ShoppingCartVM.OrderTotal += (cart.Price * cart.Count);
        //       // cart.Price = GetPriceBasedOnQuantity(cart);
        //    }

        //    return View(ShoppingCartVM);
        //}
        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Login", "Account"); // Redirect if user is not found
            }

            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId, includeProperties: "Product"),
                OrderTotal = 0 // Initialize to zero
            };

            if (ShoppingCartVM.ShoppingCartList != null && ShoppingCartVM.ShoppingCartList.Any())
            {
                foreach (var cart in ShoppingCartVM.ShoppingCartList)
                {
                    cart.Price = GetPriceBasedOnQuantity(cart);

                    if (cart.Price > 0 && cart.Count > 0) // Ensure price & count are valid
                    {
                        ShoppingCartVM.OrderTotal += (cart.Price * cart.Count);
                    }
                }
            }
            else
            {
                Console.WriteLine("Shopping cart is empty for user: " + userId);
            }

            return View(ShoppingCartVM);
        }


        public IActionResult Summary()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value;
            ShoppingCartVM = new()
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(u => u.ApplicationUserId == userId,
                includeProperties: "Product")
            };
            foreach (var cart in ShoppingCartVM.ShoppingCartList)
            {
                cart.Price = GetPriceBasedOnQuantity(cart);
                ShoppingCartVM.OrderTotal += (cart.Price * cart.Count);
            }
            return View(ShoppingCartVM);
        }
             
        public IActionResult Plus(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
            cartFromDb.Count += 1;
            _unitOfWork.ShoppingCart.Update(cartFromDb);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Minus(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);
            if (cartFromDb.Count <= 1)
            {
                //remove that from cart

                _unitOfWork.ShoppingCart.Remove(cartFromDb);
                //HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart
                //    .GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1);
            }
            else
            {
                cartFromDb.Count -= 1;
                _unitOfWork.ShoppingCart.Update(cartFromDb);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int cartId)
        {
            var cartFromDb = _unitOfWork.ShoppingCart.Get(u => u.Id == cartId);

            _unitOfWork.ShoppingCart.Remove(cartFromDb);

            //HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart
            //  .GetAll(u => u.ApplicationUserId == cartFromDb.ApplicationUserId).Count() - 1);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        //private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        //{

        //        return shoppingCart.Price ;



        //    //private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        //    //{
        //    //    // Implement logic to calculate price based on quantity.
        //    //    return shoppingCart.Product.Price; // Example logic, adjust as needed.
        //    //}
        //}
        private double GetPriceBasedOnQuantity(ShoppingCart shoppingCart)
        {
            if (shoppingCart.Product == null)
            {
                return 0; // Ensure product is valid
            }

            decimal productPrice = shoppingCart.Product.Price; // Store price as decimal

            if (shoppingCart.Count <= 5)
            {
                return (double)productPrice; // Convert to double
            }
            else if (shoppingCart.Count <= 10)
            {
                return (double)(productPrice * 0.95m); // Use 'm' to indicate decimal constant
            }
            else
            {
                return (double)(productPrice * 0.90m);
            }
        }


    }
}
   