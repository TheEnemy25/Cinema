using Cinema.Infrastructure.Dtos.Base;
using Cinema.Infrastructure.Entities.Interfaces;

namespace Cinema.Domain.Services.BaseService
{
    public interface IBaseService<TEntity, TDto>
        where TEntity : class, IEntityWithId
        where TDto : DtoBase
    {
        Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<TDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Guid> CreateAsync(TDto dto, CancellationToken cancellationToken = default);
        Task<TDto> UpdateAsync(TDto dto, CancellationToken cancellationToken = default);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}