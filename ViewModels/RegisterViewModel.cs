using System.ComponentModel.DataAnnotations;

namespace DemoStore.ViewModels
{
    public class RegisterViewModel
    {
        public string Username { get; set; }
        [Required] [EmailAddress] public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }

        public string ReturnUrl { get; set; }
    }
}