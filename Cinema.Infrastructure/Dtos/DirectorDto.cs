namespace Cinema.Infrastructure.Dtos
{
    public record DirectorDto
    {
        public Guid Id { get; init; }
        public string FullName { get; init; }
        public string Image { get; init; }
        public string Biography { get; init; }
        public string Country { get; init; }
        public DateTime DateOfBirth { get; init; }
    }
}
