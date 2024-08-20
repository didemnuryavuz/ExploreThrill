using ExploreThrill.Entities.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace ExploreThrill.MVC.Controllers
{
    public class AdminController(ExploreContext exploreContext) : Controller
    {
        private readonly ExploreContext _exploreContext = exploreContext;

        public IActionResult Index()
        {

            return View();

        }
    }
}
