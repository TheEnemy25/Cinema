namespace Cinema.Infrastructure.Dtos
{
    public record ActorDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Image { get; set; }
        public string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
