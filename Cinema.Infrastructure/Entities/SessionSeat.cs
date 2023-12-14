using Cinema.Infrastructure.Entities.Interfaces;
using Cinema.Infrastructure.Enums;

namespace Cinema.Infrastructure.Entities
{
    public class SessionSeat : IEntity
    {
        public Guid SessionId { get; set; }
        public Guid SeatId { get; set; }

        public ESeatStatus Status { get; set; } // Статус місця

        public Session Session { get; set; }
        public Seat Seat { get; set; }
    }
}
