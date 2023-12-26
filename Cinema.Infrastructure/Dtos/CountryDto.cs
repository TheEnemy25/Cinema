namespace Cinema.Infrastructure.Dtos
{
    public record CountryDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string CountryCode { get; init; }
    }
}
