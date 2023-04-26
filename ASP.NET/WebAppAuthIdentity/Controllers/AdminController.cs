using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using WebAppAuthIdentity.Models;
using WebAppAuthIdentity.Service;

namespace WebAppAuthIdentity.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<AppUser> userManager;

        public AdminController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.Name,
                    Email = user.Email
                };
                IdentityResult result = await userManager.CreateAsync(appUser);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(user);
        }

        public async Task<IActionResult> Update(string id)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id, string email, string password)
        {
            AppUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrWhiteSpace(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                IdentityResult result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("index");
                else
                    return View(user);
            }
            else
                ModelState.AddModelError("", "User not found");
            return View(user);
        }
    }
}
