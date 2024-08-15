using ExploreThrill.BL.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExploreThrill.MVC.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityManager _activityManager;
        private readonly ICityManager _cityManager;
        private readonly ICategoryManager _categoryManager;
        private readonly ICompanyManager _companyManager;

        public ActivityController(IActivityManager activityManager, ICityManager cityManager, ICategoryManager categoryManager, ICompanyManager companyManager)
        {
            _activityManager = activityManager;
            _cityManager = cityManager;
            _categoryManager = categoryManager;
            _companyManager = companyManager;
        }

        // GET: Activity
        public async Task<IActionResult> Index()
        {
            var activities = await _activityManager.GetAllIncludeAsync(
                null,
                a => a.Images,
                a => a.Reviews,
                a => a.Cities,
                a => a.Categories,
                a => a.Companies);

            return View(activities);
        }

        // GET: Activity/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var activity = (await _activityManager.GetAllIncludeAsync(
                a => a.Id == id,
                a => a.Images,
                a => a.Reviews,
                a => a.Cities,
                a => a.Categories,
                a => a.Companies)).FirstOrDefault();

            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activity/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Cities"] = await _cityManager.GetAllAsync(null);
            ViewData["Categories"] = await _categoryManager.GetAllAsync(null);
            ViewData["Companies"] = await _companyManager.GetAllAsync(null);
            return View();
        }

        // POST: Activity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Activity activity, int[] selectedCities, int[] selectedCategories, int[] selectedCompanies)
        {
            if (ModelState.IsValid)
            {
                // Şehirler, kategoriler ve şirketler ile ilişkileri ayarlama
                activity.Cities = (ICollection<City>)await _cityManager.GetByIdsAsync(selectedCities);
                activity.Categories = (ICollection<Category>)await _categoryManager.GetByIdsAsync(selectedCategories);
                activity.Companies = (ICollection<Company>)await _companyManager.GetByIdsAsync(selectedCompanies);

                await _activityManager.AddAsync(activity);
                return RedirectToAction(nameof(Index));
            }

            ViewData["Cities"] = await _cityManager.GetAllAsync(null);
            ViewData["Categories"] = await _categoryManager.GetAllAsync(null);
            ViewData["Companies"] = await _companyManager.GetAllAsync(null);
            return View(activity);
        }

        // GET: Activity/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var activity = (await _activityManager.GetAllIncludeAsync(
                a => a.Id == id,
                a => a.Cities,
                a => a.Categories,
                a => a.Companies)).FirstOrDefault();

            if (activity == null)
            {
                return NotFound();
            }

            ViewData["Cities"] = await _cityManager.GetAllAsync(null);
            ViewData["Categories"] = await _categoryManager.GetAllAsync(null);
            ViewData["Companies"] = await _companyManager.GetAllAsync(null);

            return View(activity);
        }

        // POST: Activity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Activity activity, int[] selectedCities, int[] selectedCategories, int[] selectedCompanies)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Mevcut ilişkileri güncelleme
                    var existingActivity = (await _activityManager.GetAllIncludeAsync(
                        a => a.Id == id,
                        a => a.Cities,
                        a => a.Categories,
                        a => a.Companies)).FirstOrDefault();

                    if (existingActivity == null)
                    {
                        return NotFound();
                    }

                    existingActivity.ActivityName = activity.ActivityName;
                    existingActivity.Description = activity.Description;
                    existingActivity.Capacity = activity.Capacity;
                    existingActivity.Price = activity.Price;
                    existingActivity.ActivityDate = activity.ActivityDate;

                    existingActivity.Cities = (ICollection<City>)await _cityManager.GetByIdsAsync(selectedCities);
                    existingActivity.Categories = (ICollection<Category>)await _categoryManager.GetByIdsAsync(selectedCategories);
                    existingActivity.Companies = (ICollection<Company>)await _companyManager.GetByIdsAsync(selectedCompanies);

                    await _activityManager.UpdateAsync(existingActivity);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ActivityExists(activity.Id))
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

            ViewData["Cities"] = await _cityManager.GetAllAsync(null);
            ViewData["Categories"] = await _categoryManager.GetAllAsync(null);
            ViewData["Companies"] = await _companyManager.GetAllAsync(null);

            return View(activity);
        }

        // GET: Activity/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var activity = (await _activityManager.GetAllIncludeAsync(a => a.Id == id)).FirstOrDefault();
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = (await _activityManager.GetAllIncludeAsync(a => a.Id == id)).FirstOrDefault();
            if (activity != null)
            {
                await _activityManager.DeleteAsync(activity);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ActivityExists(int id)
        {
            var activity = (await _activityManager.GetAllIncludeAsync(a => a.Id == id)).FirstOrDefault();
            return activity != null;
        }
    }
}
