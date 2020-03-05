using Microsoft.AspNetCore.Mvc;

namespace NorthwindApiSampler.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}