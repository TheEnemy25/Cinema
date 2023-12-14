using Cinema.Infrastructure.Entities.Interfaces;
using Cinema.Infrastructure.Enums;

namespace Cinema.Infrastructure.Entities
{
    // Пропуск на фільм
    public class Ticket : IEntity
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid ReceiptId { get; set; }
        public Guid SessionSeatId { get; set; }

        public ETicketStatus Status { get; set; } // Статус чеку
        public int Row { get; set; }
        public int SeatNumber { get; set; }

        public Session Session { get; set; } // ?
        public SessionSeat SessionSeat { get; set; }
        public Receipt Receipt { get; set; }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
