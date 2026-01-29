using Microsoft.AspNetCore.Mvc;

namespace SoftwareSubscriptionApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
