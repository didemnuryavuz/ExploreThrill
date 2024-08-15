using ExploreThrill.BL.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ExploreThrill.MVC.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ICompanyManager _companyManager;

        public CompanyController(ICompanyManager companyManager)
        {
            _companyManager = companyManager;
        }

        // GET: Company
        public async Task<IActionResult> Index()
        {
            var companies = await _companyManager.GetAllAsync(null);
            return View(companies);
        }

        // GET: Company/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var company = await _companyManager.GetByAsync(p => p.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Company company)
        {
            if (ModelState.IsValid)
            {
                await _companyManager.AddAsync(company);
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Company/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var company = await _companyManager.GetByAsync(p => p.Id == id);
            if (company == null)
            {
                return NotFound();
            }
            return View(company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Company company)
        {
            if (id != company.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _companyManager.UpdateAsync(company);
                }
                catch (System.Exception)
                {
                    if (!await CompanyExists(company.Id))
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
            return View(company);
        }

        // GET: Company/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var company = await _companyManager.GetByAsync(p => p.Id == id);
            if (company == null)
            {
                return NotFound();
            }

            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var company = await _companyManager.GetByAsync(p => p.Id == id);
            if (company != null)
            {
                await _companyManager.DeleteAsync(company);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CompanyExists(int id)
        {
            var company = await _companyManager.GetByAsync(p => p.Id == id);
            return company != null;
        }
    }
}

