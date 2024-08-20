using ExploreThrill.BL.Abstract;
using ExploreThrill.Entities.Contexts;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ExploreThrill.MVC.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityManager _activityManager;
        private readonly ICategoryManager _categoryManager;
        private readonly ICompanyManager _companyManager;
        private readonly ICityManager _cityManager;
        private readonly ExploreContext _context;

        public ActivityController(
            IActivityManager activityManager,
            ICategoryManager categoryManager,
            ICompanyManager companyManager,
            ICityManager cityManager,
            ExploreContext context
            )
        {
            _activityManager = activityManager;
            _categoryManager = categoryManager;
            _companyManager = companyManager;
            _cityManager = cityManager;
            _context = context;
        }

        private async Task LoadViewBags()
        {
            ViewBag.Categories = new SelectList(await _categoryManager.GetAllAsync(null), "Id", "CategoryName");
            ViewBag.Companies = new SelectList(await _companyManager.GetAllAsync(null), "Id", "CompanyName");
            ViewBag.Cities = new SelectList(await _cityManager.GetAllAsync(null), "Id", "CityName");
        }

        public async Task<IActionResult> Index()
        {
            var activities = await _activityManager.GetAllIncludeAsync(null, x => x.Category, x => x.Company, x => x.Cities);
            return View(activities);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var categories = _context.Categories.ToList();
            var cities = _context.Cities.ToList();
            var companies = _context.Companies.ToList();
            var newModel = new ActivityViewModel()
            {
                Categories = categories,
                Cities = cities,
                Companies = companies,
            };

            return View(newModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActivityViewModel model)
        {
            if (ModelState.IsValid)
            {
                var activity = new Activity
                {
                    ActivityName = model.ActivityName,
                    Description = model.Description,
                    Capacity = model.Capacity,
                    Price = model.Price,
                    ActivityDate = model.ActivityDate,
                    CategoryId = model.SelectedCategory,
                    CompanyId = model.SelectedCompany,
                    Cities = new List<City>()

                };
                foreach (var cityId in model.SelectedCities)
                {
                    var city = await _cityManager.GetByAsync(c => c.Id == cityId);
                    if (city != null)
                    {
                        activity.Cities.Add(city);
                    }
                }
                await _activityManager.AddAsync(activity);
                return RedirectToAction(nameof(Index));
            }

            await LoadViewBags();
            return View(model);
        }

        #region Edit Düzenlenecek
        //[HttpGet]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    var activity = _context.Activities.Include(x => x.Company).Include(x => x.Category).Include(x => x.Cities).Where(x => x.Id == id).FirstOrDefault();

        //    /// var activity = await _activityManager.GetByAsync(x => x.Id == id);
        //    if (activity == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new ActivityViewModel
        //    {
        //        Id = activity.Id,
        //        ActivityName = activity.ActivityName,
        //        Description = activity.Description,
        //        Capacity = activity.Capacity,
        //        Price = activity.Price,
        //        ActivityDate = activity.ActivityDate,
        //        SelectedCategory = activity.CategoryId,
        //        SelectedCompany = activity.CompanyId,
        //        SelectedCities = activity.Cities.Select(c => c.Id).ToList()
        //    };

        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, ActivityViewModel model)
        //{
        //    if (id != model.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        var activity = _context.Activities.Include(x => x.Company).Include(x => x.Category).Include(x => x.Cities).Where(x => x.Id == id).FirstOrDefault();

        //        // var activity = await _activityManager.GetByAsync(x => x.Id == id);

        //        if (activity == null)
        //        {
        //            return NotFound();
        //        }

        //        activity.ActivityName = model.ActivityName;
        //        activity.Description = model.Description;
        //        activity.Capacity = model.Capacity;
        //        activity.Price = model.Price;
        //        activity.ActivityDate = model.ActivityDate;
        //        activity.CategoryId = model.SelectedCategory;
        //        activity.CompanyId = model.SelectedCompany;
        //        activity.Cities = model.SelectedCities.Select(cityId => new City { Id = cityId }).ToList();

        //        await _activityManager.UpdateAsync(activity);
        //        return RedirectToAction(nameof(Index));
        //    }

        //    //await LoadViewBags();
        //    return View(model);
        //} 
        #endregion

        public async Task<IActionResult> Delete(int id)
        {
            var activity = _context.Activities.Include(x => x.Company).Include(x => x.Category).Include(x => x.Cities).Where(x => x.Id == id).FirstOrDefault();


            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {


            var activity = await _activityManager.GetByAsync(x => x.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            await _activityManager.DeleteAsync(activity);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {

            var activity = _context.Activities.Include(x => x.Company).Include(x => x.Category).Include(x => x.Cities).Where(x => x.Id == id).FirstOrDefault();


            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }
    }
}
