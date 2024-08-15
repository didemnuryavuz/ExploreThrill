using ExploreThrill.Core.Entities.Abstract;

namespace ExploreThrill.Entities.Models.Concrete
{
    public class Image : BaseEntity<int>
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
