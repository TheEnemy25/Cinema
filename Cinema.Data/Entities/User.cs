using Microsoft.AspNetCore.Identity;

namespace Cinema.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime RegistrationDate { get; set; }


        public ICollection<CartItem> CartItems { get; set; } // Список елементів корзини
    }
}
