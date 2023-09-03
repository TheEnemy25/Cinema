using Cinema.Data.Enums;

namespace Cinema.Data.Entities
{
    public class Seat
    {
        public Guid Id { get; set; }
        public Guid HallId { get; set; }

        public int Row { get; set; }
        public int Number { get; set; }
        public ESeatStatus Status { get; set; } // Статус місця

        //Relationships
        public Hall Hall { get; set; }
        public ICollection<SessionSeat> SessionSeats { get; set; }
        public ICollection<ShoppingCartItem > ShoppingCartItems { get; set; }
    }
}
