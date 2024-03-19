using AutoMapper;
using Cinema.Infrastructure.Dtos.Base;
using Cinema.Infrastructure.Entities.Interfaces;
using Cinema.Infrastructure.Exceptions;
using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.BaseService
{
    internal abstract class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
        where TEntity : class, IEntityWithId
        where TDto : DtoBase
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

        public virtual async Task<Guid> CreateAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto, CancellationToken cancellationToken = default)
        {
            var entity = await _repository.GetByIdAsync(dto.Id);
                
            if (entity == null)
            {
                throw new EntityNotFoundException($"{typeof(TEntity).Name} was not found");
            }

            _mapper.Map(dto, entity);

            await _repository.UpdateAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);

            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var entityToDelete = await _repository.GetByIdAsync(id);

            if (entityToDelete == null)
            {
                throw new EntityNotFoundException($"Actor with id {id} was not found");
            }

            await _repository.DeleteAsync(entityToDelete, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }
    }
}