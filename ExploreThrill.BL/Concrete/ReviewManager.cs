using ExploreThrill.BL.Abstract;
using ExploreThrill.Core.Business.Concrete;
using ExploreThrill.Entities.Contexts;
using ExploreThrill.Entities.Models.Concrete;

namespace ExploreThrill.BL.Concrete
{
    public class ReviewManager : Manager<Review, int, ExploreContext>, IReviewManager
    {
        public ReviewManager(ExploreContext context) : base(context)
        {
        }

    }
}
