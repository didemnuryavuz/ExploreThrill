using ExploreThrill.Core.Entities.Abstract;

namespace ExploreThrill.Entities.Models.Concrete
{
    public class Activity : BaseEntity<int>
    {
        public string ActivityName { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
        public decimal Price { get; set; }
        public DateTime ActivityDate { get; set; }

        #region 1-N

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        #endregion

        #region N-N
        public ICollection<City>? Cities { get; set; }

        #endregion

    }
}