using Microsoft.AspNetCore.Identity;

namespace BeavenLearningBackend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } 
        public string UserName { get; set; } 
        public string Password { get; set; } 
        public string Role { get; set; } 
    }
}
