using Cinema.Infrastructure.Dtos.Base;
using Cinema.Infrastructure.Enums;

namespace Cinema.Infrastructure.Dtos
{
    public record HallDto : DtoBase
    {
        public Guid CinemaTheaterId { get; init; }
        public int Number { get; init; }
        public int Rows { get; init; }
        public int SeatsPerRow { get; init; }
        public int NormalSeatsCount { get; init; }
        public int VIPSeatsCount { get; init; }
        public EHallType HallType { get; init; }
        public EHallStatus Status { get; init; }
        public decimal BasePrice { get; init; }
        public decimal VIPPrice { get; init; }

    }
}
