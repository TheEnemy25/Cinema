using Cinema.Infrastructure.Dtos.Base;
using Cinema.Infrastructure.Enums;

namespace Cinema.Infrastructure.Dtos
{
    public record SessionSeatDto : DtoBase
    {
        public Guid SessionId { get; init; }
        public Guid SeatId { get; init; }
        public ESeatStatus Status { get; init; }
    }
}
