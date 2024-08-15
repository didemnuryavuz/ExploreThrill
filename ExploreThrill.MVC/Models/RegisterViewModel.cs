using System.ComponentModel.DataAnnotations;

namespace ExploreThrill.MVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter a valid T.C. Identification Number.")]
        [MaxLength(11)]
        public string TcNo { get; set; }
    }
}
