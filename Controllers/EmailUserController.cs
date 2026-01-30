using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoftwareSubscriptionApp.Data;
using SoftwareSubscriptionApp.Models;

namespace SoftwareSubscriptionApp.Controllers
{
    [Authorize]
    public class EmailUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var users = _context.EmailUsers.ToList();
            return View(users);
        }

        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Create(EmailUser user)
        {
            if (ModelState.IsValid)
            {
                _context.EmailUsers.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Edit(int id)
        {
            var emailUser = _context.EmailUsers.Find(id);
            if (emailUser == null) return NotFound();
            return View(emailUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Edit(int id, EmailUser user)
        {
            if (id != user.Id) return NotFound();
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                var existing = _context.EmailUsers.AsNoTracking().FirstOrDefault(e => e.Id == id);
                if (existing != null) user.Password = existing.Password;
                ModelState.Remove("Password");
            }
            if (ModelState.IsValid)
            {
                _context.Update(user);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult Delete(int id)
        {
            var emailUser = _context.EmailUsers.Find(id);
            if (emailUser == null) return NotFound();
            return View(emailUser);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Admin)]
        public IActionResult DeleteConfirmed(int id)
        {
            var emailUser = _context.EmailUsers.Find(id);
            if (emailUser != null)
            {
                _context.EmailUsers.Remove(emailUser);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
