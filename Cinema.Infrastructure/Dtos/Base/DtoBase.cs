namespace Cinema.Infrastructure.Dtos.Base
{
    public abstract record DtoBase
    {
        public Guid Id { get; init; }
    }
}