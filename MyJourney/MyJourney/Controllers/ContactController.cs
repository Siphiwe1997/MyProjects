using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyJourney.Data;
using MyJourney.Models;

namespace MyJourney.Controllers
{
    public class ContactController : Controller
    {

        private readonly IRepositoryWrapper _repo;
        private readonly UserManager<IdentityUser> _userManager;
        public ContactController(IRepositoryWrapper repo, UserManager<IdentityUser> userManager)
        {
            _repo = repo;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var user = _userManager.GetUserAsync(User).Result;
            // Pass user details to the view
            var contact = new Contact
            {
                Name = user.UserName,
                Email = user.Email
            };
            return View(contact);
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                _repo.Contact.Create(contact);
                _repo.Save();
                TempData["Message"] = "Thank you. I'll get in touch soon!";
                return RedirectToAction("Index","Contact");
            }
            else
            {
                return View();
            }
        }
    }
}
