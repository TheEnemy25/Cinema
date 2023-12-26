using Cinema.Infrastructure.Enums;

namespace Cinema.Infrastructure.Dtos
{
    public record TicketDto
    {
        public Guid Id { get; init; }
        public Guid SessionId { get; init; }
        public Guid ReceiptId { get; init; }
        public Guid SessionSeatId { get; init; }
        public ETicketStatus Status { get; init; }
        public int Row { get; init; }
        public int SeatNumber { get; init; }
    }
}
