using ExploreThrill.Core.Entities.Concrete;

namespace ExploreThrill.Core.Entities.Abstract
{
    public abstract class BaseEntity<TId>
    {
        public TId Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public string? MyUserId { get; set; }
        public MyUser? MyUser { get; set; }
    }
}
