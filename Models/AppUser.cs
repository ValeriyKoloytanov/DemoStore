using Microsoft.AspNetCore.Identity;

namespace DemoStore.Models
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] ProfilePicture { get; set; }

    }
}