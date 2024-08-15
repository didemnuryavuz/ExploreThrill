using ExploreThrill.BL.Abstract;
using ExploreThrill.Core.Business.Concrete;
using ExploreThrill.Entities.Contexts;
using ExploreThrill.Entities.Models.Concrete;

namespace ExploreThrill.BL.Concrete
{
    public class ActivityManager : Manager<Activity, int, ExploreContext>, IActivityManager
    {
        public ActivityManager(ExploreContext context) : base(context)
        {
        }


    }
}
