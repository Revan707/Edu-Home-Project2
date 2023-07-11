using EduHome2.Core.Entities;
using EduHome2.UI.ViewModels;
using EduHome2.UI.ViewModels.AuthViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EduHome2.UI.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM newUser)
        {
            if(!ModelState.IsValid) return View(newUser);
            AppUser user = new()
            {
                Fullname= newUser.Fullname,
                UserName=newUser.Username,
                 Email=newUser.Email,
            };
            IdentityResult result = await _userManager.CreateAsync(user, newUser.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(newUser);
            }
            return Ok();
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
