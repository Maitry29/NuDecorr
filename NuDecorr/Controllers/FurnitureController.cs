using Microsoft.AspNetCore.Mvc;

namespace NuDecorr.Controllers
{
    public class FurnitureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
