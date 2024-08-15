using ExploreThrill.BL.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ExploreThrill.MVC.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityManager _cityManager;

        public CityController(ICityManager cityManager)
        {
            _cityManager = cityManager;
        }

        // GET: City
        public async Task<IActionResult> Index()
        {
            var cities = await _cityManager.GetAllAsync(null);
            return View(cities);
        }

        // GET: City/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var city = await _cityManager.GetByAsync(p => p.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // GET: City/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                await _cityManager.AddAsync(city);
                return RedirectToAction(nameof(Index));
            }
            return View(city);
        }

        // GET: City/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var city = await _cityManager.GetByAsync(p => p.Id == id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: City/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, City city)
        {
            if (id != city.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _cityManager.UpdateAsync(city);
                }
                catch (System.Exception)
                {
                    if (!await CityExists(city.Id))
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
            return View(city);
        }

        // GET: City/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var city = await _cityManager.GetByAsync(p => p.Id == id);
            if (city == null)
            {
                return NotFound();
            }

            return View(city);
        }

        // POST: City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var city = await _cityManager.GetByAsync(p => p.Id == id);
            if (city != null)
            {
                await _cityManager.DeleteAsync(city);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CityExists(int id)
        {
            var city = await _cityManager.GetByAsync(p => p.Id == id);
            return city != null;
        }
    }
}

