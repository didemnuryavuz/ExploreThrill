using ExploreThrill.Core.Entities.Abstract;

namespace ExploreThrill.Entities.Models.Concrete
{
    public class Company : BaseEntity<int>
    {
        public string CompanyName { get; set; }
        public string? Description { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string? Address { get; set; }
        public ICollection<Activity>? Activities { get; set; }
    }
}
