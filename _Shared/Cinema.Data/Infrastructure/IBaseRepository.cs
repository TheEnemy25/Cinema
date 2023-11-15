using System.Linq.Expressions;

namespace Exam.Data.Infrastructure
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes);
        ValueTask<TEntity> GetByIdAsync(params object[] keys);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteRangeAsync(IEnumerable<TEntity> entities);
        Task DeleteAsync(TEntity entity);
        Task DetachAsync(TEntity entity);
        Task<int> SaveChangesAsync();
    }
}