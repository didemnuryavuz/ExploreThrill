using ExploreThrill.BL.Abstract;
using ExploreThrill.Entities.Models.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ExploreThrill.MVC.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageManager _imageManager;

        public ImageController(IImageManager imageManager)
        {
            _imageManager = imageManager;
        }

        // GET: Image
        public async Task<IActionResult> Index()
        {
            var images = await _imageManager.GetAllAsync(null);
            return View(images);
        }

        // GET: Image/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var image = await _imageManager.GetByAsync(p => p.Id == id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Image/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Image image)
        {
            if (ModelState.IsValid)
            {
                await _imageManager.AddAsync(image);
                return RedirectToAction(nameof(Index));
            }
            return View(image);
        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var image = await _imageManager.GetByAsync(p => p.Id == id);
            if (image == null)
            {
                return NotFound();
            }
            return View(image);
        }

        // POST: Image/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Image image)
        {
            if (id != image.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _imageManager.UpdateAsync(image);
                }
                catch (System.Exception)
                {
                    if (!await ImageExists(image.Id))
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
            return View(image);
        }

        // GET: Image/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var image = await _imageManager.GetByAsync(p => p.Id == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var image = await _imageManager.GetByAsync(p => p.Id == id);
            if (image != null)
            {
                await _imageManager.DeleteAsync(image);
            }
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ImageExists(int id)
        {
            var image = await _imageManager.GetByAsync(p => p.Id == id);
            return image != null;
        }
    }
}

