using Microsoft.AspNetCore.Mvc;
using SoftwareSubscriptionApp.Data;
using SoftwareSubscriptionApp.Models;

namespace SoftwareSubscriptionApp.Controllers
{
    public class EmailUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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

        public IActionResult Index()
        {
            var users = _context.EmailUsers.ToList();
            return View(users);
        }
    }
}
