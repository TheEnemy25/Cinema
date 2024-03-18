using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record MovieDto : DtoBase
    {
        public string Title { get; init; }
        public int AgeRestriction { get; init; }
        public string Description { get; init; }
        public string ImageLink { get; init; }
        public string TrailerLink { get; init; }
        public double Rating { get; init; }
        public TimeSpan Duration { get; init; }
        public DateTime ReleaseDate { get; init; }
    }
}
