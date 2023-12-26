namespace Cinema.Infrastructure.Dtos
{
    public record ProductionCountryDto
    {
        public Guid Id { get; init; }
        public string CountryName { get; init; }
    }
}
