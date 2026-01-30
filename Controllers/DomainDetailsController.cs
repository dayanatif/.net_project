using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareSubscriptionApp.Data;
using SoftwareSubscriptionApp.Models;

namespace SoftwareSubscriptionApp.Controllers
{
    [Authorize]
    public class DomainDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DomainDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var domains = _context.DomainDetails.ToList();
            return View(domains);
        }

        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Admin)]
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

        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Edit(int id)
        {
            var domain = _context.DomainDetails.Find(id);
            if (domain == null) return NotFound();
            return View(domain);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Edit(int id, DomainDetails domain)
        {
            if (id != domain.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(domain);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(domain);
        }

        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Delete(int id)
        {
            var domain = _context.DomainDetails.Find(id);
            if (domain == null) return NotFound();
            return View(domain);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult DeleteConfirmed(int id)
        {
            var domain = _context.DomainDetails.Find(id);
            if (domain != null)
            {
                _context.DomainDetails.Remove(domain);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
