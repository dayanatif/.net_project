using Microsoft.AspNetCore.Mvc;
using SoftwareSubscriptionApp.Data;
using SoftwareSubscriptionApp.Models;

namespace SoftwareSubscriptionApp.Controllers
{
    public class SoftwareSubscriptionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SoftwareSubscriptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SoftwareSubscription subscription)
        {
            if (ModelState.IsValid)
            {
                _context.SoftwareSubscriptions.Add(subscription);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscription);
        }

        public IActionResult Index()
        {
            var subscriptions = _context.SoftwareSubscriptions.ToList();
            return View(subscriptions);
        }
    }
}
