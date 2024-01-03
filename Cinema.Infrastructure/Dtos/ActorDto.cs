namespace Cinema.Infrastructure.Dtos
{
    public record ActorDto
    {
        public Guid Id { get; init; }
        public string FullName { get; init; }
        public string Image { get; init; }
        public string Biography { get; init; }
        public DateTime DateOfBirth { get; init; }
    }
}
