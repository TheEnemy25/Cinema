using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record ActorDto : DtoBase
    {
        public string FullName { get; init; }
        public string Image { get; init; }
        public string Biography { get; init; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; init; }
    }
}
