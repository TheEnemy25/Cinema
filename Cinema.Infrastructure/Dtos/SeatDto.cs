using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record SeatDto : DtoBase
    {
        public Guid HallId { get; init; }
        public int Row { get; init; }
        public int Number { get; init; }
    }
}
