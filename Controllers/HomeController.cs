using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareSubscriptionApp.Models;

namespace SoftwareSubscriptionApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Error(string? requestId = null)
        {
            return View(new ErrorViewModel { RequestId = requestId ?? HttpContext.TraceIdentifier });
        }
    }
}
