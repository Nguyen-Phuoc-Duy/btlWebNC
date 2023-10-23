using Microsoft.AspNetCore.Identity;

namespace btlWebNC.Models.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }

    }
}
