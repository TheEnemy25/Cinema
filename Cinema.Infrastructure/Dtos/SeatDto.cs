namespace Cinema.Infrastructure.Dtos
{
    public record SeatDto
    {
        public Guid Id { get; init; }
        public Guid HallId { get; init; }
        public int Row { get; init; }
        public int Number { get; init; }
    }
}
