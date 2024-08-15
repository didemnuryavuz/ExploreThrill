using ExploreThrill.Core.Entities.Concrete;
using ExploreThrill.MVC.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ExploreThrill.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<MyUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // Admin Dashboard Index
        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                TotalUsers = _userManager.Users.Count(),
                TotalRoles = _roleManager.Roles.Count(),
                TotalAdmins = _userManager.GetUsersInRoleAsync("Admin").Result.Count()
            };

            return View(model);
        }
    }
}
