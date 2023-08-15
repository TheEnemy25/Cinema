using Cinema.Data.Enums;

namespace Cinema.Data.Entities
{
    // Пропуск на фільм
    public class Ticket
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; } // Зовнішній ключ для сесії

        public ETicketStatus Status { get; set; } // Статус чеку
        public int Row { get; set; }
        public int SeatNumber { get; set; }


        public Session Session { get; set; } // Зв'язок з сеансом
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
