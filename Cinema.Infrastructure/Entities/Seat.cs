using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Infrastructure.Entities
{
    public class Seat : IEntityWithId
    {
        public Guid Id { get; set; }
        public Guid HallId { get; set; }

        public int Row { get; set; }
        public int Number { get; set; }

        //Relationships
        public Hall Hall { get; set; }
        public ICollection<SessionSeat> SessionSeats { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
