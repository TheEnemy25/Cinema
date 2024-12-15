using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record GenreDto : DtoBase
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string ImageURL { get; init; }
    }
}
