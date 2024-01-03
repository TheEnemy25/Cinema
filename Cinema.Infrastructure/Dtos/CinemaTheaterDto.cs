namespace Cinema.Infrastructure.Dtos
{
    public record CinemaTheaterDto
    {
        public Guid Id { get; init; }
        public Guid CityId { get; init; }

        public string Address { get; init; }
        public string ContactInfo { get; init; }
    }
}
