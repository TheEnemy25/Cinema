using AutoMapper;
using Cinema.Infrastructure.Entities.Interfaces;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.BaseService
{
    internal abstract class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
        where TEntity : class, IEntity
        where TDto : class
    {
        protected readonly IBaseRepository<TEntity> _repository;
        protected readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync(CancellationToken cancellationToken = default) =>
                   await _repository.Query().Select(entity => _mapper.Map<TDto>(entity)).ToListAsync(cancellationToken);

        public virtual async Task<TDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            _mapper.Map<TDto>(await _repository.GetByIdAsync(id, cancellationToken));

        public virtual async Task CreateAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task UpdateAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _repository.UpdateAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entityToDelete = await _repository.GetByIdAsync(id);

            if (entityToDelete != null)
            {
                await _repository.DeleteAsync(entityToDelete, cancellationToken);
                await _repository.SaveChangesAsync(cancellationToken);
            }
        }
    }
}