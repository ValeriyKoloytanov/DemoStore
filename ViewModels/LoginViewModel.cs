using System.ComponentModel.DataAnnotations;

namespace DemoStore.ViewModels
{
    public class LoginViewModel
    {
        public string Username { get; set; }

        [Required] [EmailAddress]  public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}