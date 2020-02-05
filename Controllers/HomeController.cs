using Microsoft.AspNetCore.Mvc;

namespace WeatherSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
