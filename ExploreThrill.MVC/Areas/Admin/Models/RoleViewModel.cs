using System.ComponentModel.DataAnnotations;

namespace ExploreThrill.MVC.Areas.Admin.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Role Name is required.")]
        [StringLength(256, ErrorMessage = "Role Name cannot exceed 256 characters.")]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
