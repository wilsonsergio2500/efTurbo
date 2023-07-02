using Ardalis.Specification;
using EF.Turbo.Repo.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace EF.Turbo.Repo.Core.Interfaces
{
    /// <inheritdoc cref="IRepositoryBase{TEntity}"/>
    public interface IBaseRepo<TDbContext, TEntity>: IRepositoryBase<TEntity> where TDbContext : DbContext where TEntity : BaseEntity
    {
        new
                /// <summary>
                /// Updates an entity in the database
                /// </summary>
                /// <param name="entity">The entity to update.</param>
                /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
                /// <returns>A task that represents the asynchronous operation.</returns>
                Task<TEntity?> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the Entity of <typeparamref name="TEntity"/> by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cancellationToken">A <see cref="CancellationToken" /> to observe while waiting for the task to complete.</param>
        /// <returns></returns>
        Task DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
