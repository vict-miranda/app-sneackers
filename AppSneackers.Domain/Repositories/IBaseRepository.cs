using AppSneackers.Domain.Entities;
using System.Linq.Expressions;

namespace AppSneackers.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Gets the specified entity.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        /// <param name="cancellationToken">The cancellation token for this transaction</param>
        /// <returns></returns>
        Task<TEntity> GetById(int id);

        /// <summary>
        /// Get the specified entity that accomplish the expression given
        /// </summary>
        /// <param name="cancellationToken">The cancellation token for the task</param>
        /// <param name="filter">The expression of the entity to filter the results</param>
        /// <param name="orderBy">The function to order the results in case it exist more than one.</param>
        /// <param name="includeProperties">Related fields of the entity</param>
        /// <returns></returns>
        Task<List<TEntity>> GetAsync(
            CancellationToken cancellationToken,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity to add.</param>
        Task Create(TEntity entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task Update(int id, TEntity entity);

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        Task Delete(int id);
    }
}
