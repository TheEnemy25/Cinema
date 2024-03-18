using Cinema.Infrastructure.Entities.Interfaces;
using Cinema.Infrastructure.Enums;

namespace Cinema.Infrastructure.Entities
{
    public class SessionSeat : IEntityWithId
    {
        public Guid Id { get; set; }
        public Guid SessionId { get; set; }
        public Guid SeatId { get; set; }

        public ESeatStatus Status { get; set; } // Статус місця

        public Session Session { get; set; }
        public Seat Seat { get; set; }
    }
}
