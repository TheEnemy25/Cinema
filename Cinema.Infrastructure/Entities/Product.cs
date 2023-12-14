using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class Product : IEntity
    {
        public Guid Id { get; set; }
        public Guid DiscountId { get; set; }

        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        //Relationships
        public Discount Discount { get; set; }
        public ICollection<ProductPromoCode> ProductPromoCodes { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}