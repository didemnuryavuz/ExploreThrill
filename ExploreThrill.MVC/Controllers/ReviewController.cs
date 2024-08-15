using ExploreThrill.BL.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ExploreThrill.MVC.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewManager _reviewManager;

        public ReviewController(IReviewManager reviewManager)
        {
            _reviewManager = reviewManager;
        }

        // GET: Review
        public async Task<IActionResult> Index()
        {
            var reviews = await _reviewManager.GetAllAsync(null);
            return View(reviews);
        }

        // GET: Review/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var review = await _reviewManager.GetByAsync(p => p.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // GET: Review/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Review review)
        {
            if (ModelState.IsValid)
            {
                await _reviewManager.AddAsync(review);
                return RedirectToAction(nameof(Index));
            }
            return View(review);
        }

        // GET: Review/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var review = await _reviewManager.GetByAsync(p => p.Id == id);
            if (review == null)
            {
                return NotFound();
            }
            return View(review);
        }

        // POST: Review/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Review review)
        {
            if (id != review.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _reviewManager.UpdateAsync(review);
                }
                catch (System.Exception)
                {
                    if (!await ReviewExists(review.Id))
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
            return View(review);
        }

        // GET: Review/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var review = await _reviewManager.GetByAsync(p => p.Id == id);
            if (review == null)
            {
                return NotFound();
            }

            return View(review);
        }

        // POST: Review/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var review = await _reviewManager.GetByAsync(p => p.Id == id);
            if (review != null)
            {
                await _reviewManager.DeleteAsync(review);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ReviewExists(int id)
        {
            var review = await _reviewManager.GetByAsync(p => p.Id == id);
            return review != null;
        }
    }
}

