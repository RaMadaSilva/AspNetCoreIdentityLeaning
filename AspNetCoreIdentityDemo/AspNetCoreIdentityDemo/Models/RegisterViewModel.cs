using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentityDemo.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password end Confirm password not match")]
        public string ConfirmPassword { get; set; } = string.Empty; 
    }
}
