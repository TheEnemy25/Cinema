namespace Cinema.Infrastructure.Dtos
{
    public record GenreDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string ImageURL { get; init; }
    }
}
