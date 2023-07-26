namespace Cinema.Data.Entities
{
    public class Session
    {
        public Guid Id { get; set; }
        public int SoldSeats { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
