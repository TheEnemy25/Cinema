using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record ProducerDto : DtoBase
    {
        public string FullName { get; init; }
        public string Image { get; init; }
        public string Biography { get; init; }
        public DateTime DateOfBirth { get; init; }
    }
}
