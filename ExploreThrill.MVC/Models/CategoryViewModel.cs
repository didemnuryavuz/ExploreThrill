using ExploreThrill.Entities.Models.Concrete;
using System.ComponentModel.DataAnnotations;

namespace ExploreThrill.MVC.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required.")]
        [StringLength(100, ErrorMessage = "Category Name can't be longer than 100 characters.")]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public ICollection<Activity>? Activities { get; set; }
    }
}
