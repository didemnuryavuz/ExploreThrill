using ExploreThrill.Core.Entities.Abstract;

namespace ExploreThrill.Entities.Models.Concrete
{
    public class City : BaseEntity<int>
    {
        public string Name { get; set; }
        public ICollection<Activity>? Activities { get; set; }
    }
}
