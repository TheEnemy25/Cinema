using Cinema.Infrastructure.Dtos.Base;

namespace Cinema.Infrastructure.Dtos
{
    public record StudioDto : DtoBase
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public string Image { get; init; }
    }
}
