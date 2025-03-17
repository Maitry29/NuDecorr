using Microsoft.AspNetCore.Mvc;

namespace UrbanNest.Areas.Customer.Controllers
{
    public class FurnitureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
