namespace Cinema.Infrastructure.Dtos
{
    public record CinemaTheaterDto
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }

        public string Address { get; set; }
        public string ContactInfo { get; set; }
    }
}
