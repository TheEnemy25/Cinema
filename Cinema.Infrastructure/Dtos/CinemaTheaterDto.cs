using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record CinemaTheaterDto : DtoBase
    {
        public Guid CityId { get; init; }

        public string Address { get; init; }
        public string ContactInfo { get; init; }
    }
}
