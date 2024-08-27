using Microsoft.AspNetCore.Mvc;

namespace Pustok2.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
