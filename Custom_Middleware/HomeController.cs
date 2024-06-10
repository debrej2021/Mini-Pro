using Microsoft.AspNetCore.Mvc;

namespace Custom_Middleware
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
