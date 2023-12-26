namespace Cinema.Infrastructure.Dtos
{
    public record CityDto
    {
        public Guid Id { get; init; }
        public Guid CountryId { get; init; }
        public string Name { get; init; }
    }
}
