using Microsoft.AspNetCore.Mvc;
using SoftwareSubscriptionApp.Data;
using SoftwareSubscriptionApp.Models;

namespace SoftwareSubscriptionApp.Controllers
{
    public class DomainDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DomainDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DomainDetails domain)
        {
            if (ModelState.IsValid)
            {
                _context.DomainDetails.Add(domain);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(domain);
        }

        public IActionResult Index()
        {
            var domains = _context.DomainDetails.ToList();
            return View(domains);
        }
    }
}
