using Ardalis.Specification.EntityFrameworkCore;
using EF.Turbo.Repo.Core.Entity;
using EF.Turbo.Repo.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF.Turbo.Repo.Core.Repo
{
    /// <inheritdoc cref="IBaseRepo{TContext, TEntity}"/>
    public class BaseRepo<TDbContext, TEntity> 
        : RepositoryBase<TEntity>, IBaseRepo<TDbContext, TEntity> where TDbContext : DbContext where TEntity : BaseEntity
    {
        protected readonly TDbContext dbContext;
        public BaseRepo(TDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
        /// <inheritdoc/>
        public override  async Task<TEntity?> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            TEntity? record = await GetByIdAsync(entity.Id, cancellationToken);
            if (record is not null)
            {
                dbContext.Entry(record).CurrentValues.SetValues(entity);
                await SaveChangesAsync(cancellationToken);
                return record;
            }
            return entity;
        }
        
        /// <inheritdoc/>
        public async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            TEntity? entity = await GetByIdAsync(id, cancellationToken);
            if (entity is not null)
            {
                await DeleteAsync(entity, cancellationToken);
            }
        }

    }
}
