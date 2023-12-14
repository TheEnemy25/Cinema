using Cinema.Data.Context;
using Cinema.Infrastructure.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Exam.Data.Infrastructure
{
    public sealed class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class, IEntity
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<TEntity> dbEntities;

        public BaseRepository(ApplicationDbContext context, CancellationToken cancellationToken = default)
        {
            this.context = context;
            dbEntities = this.context.Set<TEntity>();
        }

        /// <summary>
        /// Gets all entity records with included entities
        /// </summary>
        /// <param name="includes">included entities</param>
        /// <returns>IQueryable of all entity records with included entities, if includes is null this function is equal GetAll</returns>
        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = context.Set<TEntity>();
            var query = includes.Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(dbSet, (current, include) => current.Include(include));

            return query ?? dbSet;
        }

        /// <summary>
        /// Gets entity by the keys.
        /// </summary>
        /// <param name="keys">Keys for the search.</param>
        /// <returns>Entity with such keys.</returns>
        public ValueTask<TEntity> GetByIdAsync(params object[] keys) => dbEntities.FindAsync(keys);

        /// <summary>
        /// Async add entity into DBContext
        /// </summary>
        /// <param name="entity">entity</param>
        /// <exception cref="ArgumentNullException">The entity to add cannot be <see langword="null"/>.</exception>
        /// <returns>added entity</returns>
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default) =>
            (await dbEntities.AddAsync(entity, cancellationToken)).Entity;

        /// <summary>
        /// Adds a range of entities.
        /// </summary>
        /// <param name="entities">Entities to add.</param>
        /// <returns>Task.</returns>
        public Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) =>
            dbEntities.AddRangeAsync(entities, cancellationToken);

        /// <summary>
        /// Updates entity asynchronously
        /// </summary>
        /// <param name="entity">entity</param>
        /// <returns>awaitable task with updated entity</returns>
        public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default) => await Task.Run(() => dbEntities.Update(entity).Entity);

        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) =>
            await Task.Run(() => dbEntities.UpdateRange(entities), cancellationToken);

        /// <summary>
        /// Deletes range.
        /// </summary>
        /// <param name="entities">Entities to delete.</param>
        /// <returns>Task.</returns>
        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default) =>
            await Task.Run(() => entities.ToList().ForEach(item => context.Entry(item).State = EntityState.Deleted), cancellationToken);

        /// <summary>
        /// Saves changes in the database asynchronously.
        /// </summary>
        /// <returns>Task</returns>
        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await context.SaveChangesAsync(cancellationToken);
            }
            catch
            {
                if (context.Database.CurrentTransaction is not null)
                {
                    context.Database.CurrentTransaction.Rollback();
                }

                throw;
            }
        }

        /// <summary>
        /// Removes entity from DBContext
        /// </summary>
        /// <param name="entity">entity</param>
        public async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default) =>
            await Task.Run(() => context.Entry(entity).State = EntityState.Deleted, cancellationToken);

        /// <summary>
        /// Detaches entity
        /// </summary>
        /// <param name="entity">entity</param>
        public async Task DetachAsync(TEntity entity, CancellationToken cancellationToken = default) =>
            await Task.Run(() => context.Entry(entity).State = EntityState.Detached, cancellationToken);
    }
}