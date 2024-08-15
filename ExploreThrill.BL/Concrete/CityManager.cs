using ExploreThrill.BL.Abstract;
using ExploreThrill.Core.Business.Concrete;
using ExploreThrill.Entities.Contexts;
using ExploreThrill.Entities.Models.Concrete;

namespace ExploreThrill.BL.Concrete
{
    public class CityManager : Manager<City, int, ExploreContext>, ICityManager
    {
        public CityManager(ExploreContext context) : base(context)
        {
        }


    }
}
