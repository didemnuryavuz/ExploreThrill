using ExploreThrill.Core.Entities.Abstract;

namespace ExploreThrill.Entities.Models.Concrete
{
    public class Review : BaseEntity<int>
    {
        public ushort Rating { get; set; }
        public string? Comment { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }

    }
}