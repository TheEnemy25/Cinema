using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record CountryDto : DtoBase
    {
        public string Name { get; init; }
        public string CountryCode { get; init; }
    }
}
