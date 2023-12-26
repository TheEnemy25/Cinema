using Microsoft.AspNetCore.Identity;

namespace Cinema.Infrastructure.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Review> Reviews { get; set; }
        public ICollection<ShoppingCart> ShoppingCarts { get; set; }
        public ICollection<UserProductPromoCode> UserProductPromoCodes { get; set; }
        public ICollection<UserSessionPromoCode> UserSessionPromoCodes { get; set; }
    }
}