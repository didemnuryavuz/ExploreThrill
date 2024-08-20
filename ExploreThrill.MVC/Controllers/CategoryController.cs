using ExploreThrill.BL.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExploreThrill.MVC.Controllers
{
    //[Authorize(Roles = "AppUser")]
    public class CategoryController : Controller
    {
        private readonly ICategoryManager _categoryManager;

        public CategoryController(ICategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        // GET: Category
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryManager.GetAllAsync(null);
            return View(categories);
        }

        // GET: Category/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryManager.GetByAsync(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _categoryManager.AddAsync(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var category = await _categoryManager.GetByAsync(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryManager.UpdateAsync(category);
                }
                catch (System.Exception)
                {
                    if (!await CategoryExists(category.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryManager.GetByAsync(p => p.Id == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _categoryManager.GetByAsync(p => p.Id == id);
            if (category != null)
            {
                await _categoryManager.DeleteAsync(category);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CategoryExists(int id)
        {
            var category = await _categoryManager.GetByAsync(p => p.Id == id);
            return category != null;
        }
    }
}
