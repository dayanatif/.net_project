using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SoftwareSubscriptionApp.Data;
using SoftwareSubscriptionApp.Models;

namespace SoftwareSubscriptionApp.Controllers
{
    [Authorize]
    public class SoftwareSubscriptionController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SoftwareSubscriptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var subscriptions = _context.SoftwareSubscriptions.ToList();
            return View(subscriptions);
        }

        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Admin)]
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

        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Edit(int id)
        {
            var sub = _context.SoftwareSubscriptions.Find(id);
            if (sub == null) return NotFound();
            return View(sub);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Edit(int id, SoftwareSubscription subscription)
        {
            if (id != subscription.Id) return NotFound();
            if (ModelState.IsValid)
            {
                _context.Update(subscription);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subscription);
        }

        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Delete(int id)
        {
            var sub = _context.SoftwareSubscriptions.Find(id);
            if (sub == null) return NotFound();
            return View(sub);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult DeleteConfirmed(int id)
        {
            var sub = _context.SoftwareSubscriptions.Find(id);
            if (sub != null)
            {
                _context.SoftwareSubscriptions.Remove(sub);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
