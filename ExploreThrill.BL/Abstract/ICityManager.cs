using ExploreThrill.Core.Business.Abstract;
using ExploreThrill.Entities.Contexts;
using ExploreThrill.Entities.Models.Concrete;

namespace ExploreThrill.BL.Abstract
{
    public interface ICityManager : IManager<City, int, ExploreContext>
    {
    }
}
