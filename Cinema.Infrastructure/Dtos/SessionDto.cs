namespace Cinema.Infrastructure.Dtos
{
    public record SessionDto
    {
        public Guid Id { get; init; }
        public Guid HallId { get; init; }
        public Guid MovieId { get; init; }
        public Guid DiscountId { get; init; }
        public DateTime Date { get; init; }
        public TimeSpan StartTime { get; init; }
    }
}
