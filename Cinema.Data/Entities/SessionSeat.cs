using Cinema.Data.Entities.Interfaces;

namespace Cinema.Data.Entities
{
    public class SessionSeat : IEntity
    {
        public Guid SessionId { get; set; }
        public Guid SeatId { get; set; }

        public string Status { get; set; } // Статус місця

        public Session Session { get; set; }
        public Seat Seat { get; set; }
    }
}
