using System.ComponentModel.DataAnnotations;

namespace DemoStore.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required] [EmailAddress] public string Email { get; set; }
    }
}