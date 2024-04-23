using Microsoft.AspNetCore.Identity;

namespace Project3.Models
{
    public class AppUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
