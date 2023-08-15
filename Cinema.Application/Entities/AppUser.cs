using Microsoft.AspNetCore.Identity;

namespace Cinema.Application.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
//public ICollection<Review> Reviews { get; set; } // Зв'язок багато до багатьох з відгуками, що залишив користувач