using Exam.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Domain.Services.BaseService
{
    // TODO: Inject and use mapper, return and accept as a param only business models, fix generics
    internal class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        protected readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default) =>
            await _repository.Query().ToListAsync(cancellationToken);

        public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
            await _repository.GetByIdAsync(id);

        public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _repository.AddAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _repository.UpdateAsync(entity, cancellationToken);
            await _repository.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
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