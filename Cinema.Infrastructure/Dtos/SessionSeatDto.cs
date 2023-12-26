using Cinema.Infrastructure.Enums;

namespace Cinema.Infrastructure.Dtos
{
    public record SessionSeatDto
    {
        public Guid SessionId { get; init; }
        public Guid SeatId { get; init; }
        public ESeatStatus Status { get; init; }
    }
}
