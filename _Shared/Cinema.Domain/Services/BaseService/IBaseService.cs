using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Domain.Services.BaseService
{
    public interface IBaseService<TEntity, TDto>
        where TEntity : class, IEntity
        where TDto : class
    {
        Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task CreateAsync(TDto dto, CancellationToken cancellationToken = default);
        Task UpdateAsync(TDto dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}