using Microsoft.AspNetCore.Identity;

namespace BeavenLearningBackend.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } 
    }
}
