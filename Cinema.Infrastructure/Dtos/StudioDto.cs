namespace Cinema.Infrastructure.Dtos
{
    public record StudioDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string Image { get; init; }
    }
}
