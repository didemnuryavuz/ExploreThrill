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
        public ICollection<Image> Images { get; set; }
        public ICollection<Review> Reviews { get; set; }

        #endregion

        #region N-N
        public ICollection<City> Cities { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Company> Companies { get; set; }

        #endregion

    }
}