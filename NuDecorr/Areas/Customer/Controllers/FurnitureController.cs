using Microsoft.AspNetCore.Mvc;

namespace NuDecorr.Areas.Customer.Controllers
{
    public class FurnitureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
