using ExploreThrill.BL.Abstract;
using ExploreThrill.Core.Business.Concrete;
using ExploreThrill.Entities.Contexts;
using ExploreThrill.Entities.Models.Concrete;

namespace ExploreThrill.BL.Concrete
{
    public class ImageManager : Manager<Image, int, ExploreContext>, IImageManager
    {
        public ImageManager(ExploreContext context) : base(context)
        {
        }


    }
}
