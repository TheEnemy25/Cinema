using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record CityDto : DtoBase
    {
        public Guid CountryId { get; init; }
        public string Name { get; init; }
    }
}
