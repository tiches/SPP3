using System.ComponentModel.DataAnnotations;

namespace P4.Models
{
    public class AccountCreateModel
    {
        [Required(ErrorMessage = "Username is required")]
        public required string CreateUsername { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public required string CreatePassword { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string CreateFullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public required string CreateEmail { get; set; }
    }
}
