namespace ExploreThrill.MVC.Areas.Admin.Controllers
{
    using global::ExploreThrill.Core.Entities.Concrete;
    using global::ExploreThrill.MVC.Areas.Admin.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    namespace ExploreThrill.MVC.Areas.Admin.Controllers
    {
        [Area("Admin")]
        [Authorize(Roles = "Admin")]
        public class RoleController : Controller
        {
            private readonly RoleManager<IdentityRole> _roleManager;
            private readonly UserManager<MyUser> _userManager;

            public RoleController(RoleManager<IdentityRole> roleManager, UserManager<MyUser> userManager)
            {
                _roleManager = roleManager;
                _userManager = userManager;
            }

            // Rollerin listelenmesi
            public IActionResult Index()
            {
                var roles = _roleManager.Roles;
                return View(roles);
            }

            // Yeni rol oluşturma sayfası
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            // Yeni rol oluşturma işlemi
            [HttpPost]
            public async Task<IActionResult> Create(string roleName)
            {
                if (!string.IsNullOrWhiteSpace(roleName))
                {
                    var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                return View();
            }

            // Rol düzenleme sayfası
            [HttpGet]
            public async Task<IActionResult> Edit(string id)
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return NotFound();
                }

                var model = new EditRoleViewModel
                {
                    Id = role.Id,
                    RoleName = role.Name
                };

                return View(model);
            }

            // Rol düzenleme işlemi
            [HttpPost]
            public async Task<IActionResult> Edit(EditRoleViewModel model)
            {
                var role = await _roleManager.FindByIdAsync(model.Id);
                if (role == null)
                {
                    return NotFound();
                }

                role.Name = model.RoleName;
                var result = await _roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            // Rol silme işlemi
            [HttpPost]
            public async Task<IActionResult> Delete(string id)
            {
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return NotFound();
                }

                var result = await _roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return RedirectToAction("Index");
            }

            // Kullanıcıları rollere atama sayfası
            [HttpGet]
            public async Task<IActionResult> ManageUserRoles(string roleId)
            {
                ViewBag.roleId = roleId;

                var role = await _roleManager.FindByIdAsync(roleId);

                if (role == null)
                {
                    return NotFound();
                }

                var model = new List<UserRoleViewModel>();

                foreach (var user in _userManager.Users)
                {
                    var userRoleViewModel = new UserRoleViewModel
                    {
                        UserId = user.Id,
                        Username = user.UserName,
                        IsSelected = await _userManager.IsInRoleAsync(user, role.Name)
                    };
                    model.Add(userRoleViewModel);
                }

                return View(model);
            }

            // Kullanıcıları rollere atama işlemi
            [HttpPost]
            public async Task<IActionResult> ManageUserRoles(List<UserRoleViewModel> model, string roleId)
            {
                var role = await _roleManager.FindByIdAsync(roleId);

                if (role == null)
                {
                    return NotFound();
                }

                foreach (var userRole in model)
                {
                    var user = await _userManager.FindByIdAsync(userRole.UserId);

                    IdentityResult result = null;

                    if (userRole.IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await _userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if (!userRole.IsSelected && await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, role.Name);
                    }

                    if (result != null && !result.Succeeded)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }

                return RedirectToAction("Edit", new { Id = roleId });
            }
        }
    }

}
