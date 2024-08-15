using ExploreThrill.Core.Entities.Concrete;
using ExploreThrill.MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExploreThrill.MVC.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        // GET: Account/Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new MyUser { UserName = model.Email, Email = model.Email, TcNo = model.TcNo };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (!result.Succeeded)
                {
                    // Could not create user
                    ModelState.AddModelError("UserCreate", $"Could not create user. {result.Errors.First().Description}");
                    return View(model);
                }

                // If role does not exists, then create role
                if (!await _roleManager.RoleExistsAsync("AppUser"))
                {
                    var roleResult = await _roleManager.CreateAsync(new IdentityRole() { Name = "AppUser" });
                    if (!roleResult.Succeeded)
                    {
                        // Could not create role
                        ModelState.AddModelError("UserCreate", $"Could not create user. {result.Errors.First().Description}");
                        return View(model);
                    }
                }

                // Add user role
                var userResult = await _userManager.AddToRoleAsync(user, "AppUser");
                if (!userResult.Succeeded)
                {
                    // Could not add role to user
                    ModelState.AddModelError("UserCreate", $"Could not create user. {result.Errors.First().Description}");
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        // GET: Account/Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(model);
        }


        // POST: Account/Logout
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}



