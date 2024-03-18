using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record ProductionCountryDto : DtoBase
    {
        public string CountryName { get; init; }
    }
}
