using ExploreThrill.Core.Entities.Abstract;

namespace ExploreThrill.Entities.Models.Concrete
{
    public class Category : BaseEntity<int>
    {
        public string CategoryName { get; set; }
        public ICollection<Activity>? Activities { get; set; }
    }
}