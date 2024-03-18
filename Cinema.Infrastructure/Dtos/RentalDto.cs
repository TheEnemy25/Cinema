using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record RentalDto : DtoBase
    {
        public Guid MovieId { get; init; }
        public Guid CinemaTheaterId { get; init; }
        public DateTime RentalDate { get; init; }
    }
}
