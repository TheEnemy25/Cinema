namespace Cinema.Infrastructure.Dtos
{
    public record ReviewDto
    {
        public Guid Id { get; init; }
        public Guid MovieId { get; init; }
        public Guid UserId { get; init; }
        public string Content { get; init; }
        public int Rating { get; init; }
        public DateTime Date { get; init; }
    }
}
