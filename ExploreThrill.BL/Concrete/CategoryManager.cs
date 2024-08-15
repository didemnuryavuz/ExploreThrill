using ExploreThrill.BL.Abstract;
using ExploreThrill.Core.Business.Concrete;
using ExploreThrill.Entities.Contexts;
using ExploreThrill.Entities.Models.Concrete;

namespace ExploreThrill.BL.Concrete
{
    public class CategoryManager : Manager<Category, int, ExploreContext>, ICategoryManager
    {
        public CategoryManager(ExploreContext context) : base(context)
        {
        }

    }
}
