using ExploreThrill.BL.Abstract;
using ExploreThrill.Core.Business.Concrete;
using ExploreThrill.Entities.Contexts;
using ExploreThrill.Entities.Models.Concrete;

namespace ExploreThrill.BL.Concrete
{
    public class CompanyManager : Manager<Company, int, ExploreContext>, ICompanyManager
    {
        public CompanyManager(ExploreContext context) : base(context)
        {
        }


    }
}
