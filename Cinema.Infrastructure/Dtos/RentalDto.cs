namespace Cinema.Infrastructure.Dtos
{
    public record RentalDto
    {
        public Guid Id { get; init; }
        public Guid MovieId { get; init; }
        public Guid CinemaTheaterId { get; init; }
        public DateTime RentalDate { get; init; }
    }
}
