namespace Cinema.Data.Entities
{
    public class SessionSeat
    {
        public Guid SessionId { get; set; }
        public Guid SeatId { get; set; }

        public Session Session { get; set; }
        public Seat Seat { get; set; }
    }
}
