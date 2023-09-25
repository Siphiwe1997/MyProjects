using Microsoft.AspNetCore.Mvc;

namespace MyJourney.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
