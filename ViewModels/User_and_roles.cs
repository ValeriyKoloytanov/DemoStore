using System.Collections.Generic;
using DemoStore.Models;

namespace DemoStore.ViewModels
{
    public class User_and_roles
    {
        public IEnumerable<Microsoft.AspNetCore.Identity.IdentityRole> Roles;
        public IEnumerable<AppUser> users;

    }
}