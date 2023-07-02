using Ardalis.Specification;
using AutoMapper;
using EF.Turbo.Repo.Core.Entity;
using EF.Turbo.Repo.Core.Interfaces;
using EF.Turbo.Service.Core.DTOs;
using EF.Turbo.Service.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF.Turbo.Service.Core.Service
{
    /// <inheritdoc cref="IBaseService{TDbContext, TEntity, TDTO}"/>
    public class BaseService<TDbContext, TEntity, TDTO> :
        IBaseService<TDbContext, TEntity, TDTO> where TDbContext : DbContext where TEntity : BaseEntity where TDTO : BaseDTO
    {
        protected readonly IMapper autoMapper;
        protected readonly IBaseRepo<TDbContext, TEntity> baseRepo;
        public BaseService(IBaseRepo<TDbContext, TEntity> baseRepo, IMapper autoMapper)
        {
            this.baseRepo = baseRepo;
            this.autoMapper = autoMapper;
        }
        /// <inheritdoc/>
        public virtual async Task<TDTO> AddAsync(TDTO item, CancellationToken cancellationToken = default)
        {
            TEntity? entity = autoMapper.Map<TEntity>(item);
            TEntity? addedEntity = await baseRepo.AddAsync(entity, cancellationToken);
            return autoMapper.Map<TDTO>(addedEntity);
        }
        /// <inheritdoc/>
        public virtual async Task<IEnumerable<TDTO>> AddRangeAsync(IEnumerable<TDTO> items, CancellationToken cancellationToken = default)
        {
            IEnumerable<TEntity> entities = autoMapper.Map<IEnumerable<TDTO>, IEnumerable<TEntity>>(items);
            IEnumerable<TEntity> addedEntities = await baseRepo.AddRangeAsync(entities, cancellationToken);
            return autoMapper.Map<IEnumerable<TEntity>, IEnumerable<TDTO>>(addedEntities);
        }
        /// <inheritdoc/>
        public virtual async Task<TDTO?> UpdateAsync(TDTO item, CancellationToken cancellationToken = default)
        {
            return autoMapper.Map<TDTO?>(await baseRepo.UpdateAsync(autoMapper.Map<TEntity>(item), cancellationToken));
        }
        /// <inheritdoc/>
        public virtual async Task UpdateRangeAsync(IEnumerable<TDTO> items, CancellationToken cancellationToken = default)
        {
            await baseRepo.UpdateRangeAsync(autoMapper.Map<IEnumerable<TEntity>>(items), cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task DeleteAsync(TDTO item, CancellationToken cancellationToken = default)
        {
            TEntity? entity = autoMapper.Map<TEntity>(item);
            await baseRepo.DeleteAsync(entity.Id, cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await baseRepo.DeleteAsync(id, cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task DeleteRangeAsync(IEnumerable<TDTO> items, CancellationToken cancellationToken = default)
        {
            await baseRepo.DeleteRangeAsync(autoMapper.Map<IEnumerable<TEntity>>(items), cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task<TDTO?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            TEntity? entity = await baseRepo.GetByIdAsync(id, cancellationToken);
            return autoMapper.Map<TDTO>(entity);
        }
        /// <inheritdoc/>
        public virtual async Task<TDTO?> FirstOrDefaultAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
           return autoMapper.Map<TDTO>(await baseRepo.FirstOrDefaultAsync(specification, cancellationToken));
        }
        /// <inheritdoc/>
        public virtual async Task<TResult?> FirstOrDefaultAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await baseRepo.FirstOrDefaultAsync(specification, cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task<TDTO?> SingleOrDefaultAsync(ISingleResultSpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return autoMapper.Map<TDTO?>(await baseRepo.SingleOrDefaultAsync(specification, cancellationToken));
        }
        /// <inheritdoc/>
        public virtual async Task<TResult?> SingleOrDefaultAsync<TResult>(ISingleResultSpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await baseRepo.SingleOrDefaultAsync(specification, cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task<List<TDTO>> ListAsync(CancellationToken cancellationToken = default)
        {
            return autoMapper.Map<List<TEntity>, List<TDTO>>(await baseRepo.ListAsync(cancellationToken));
        }
        /// <inheritdoc/>
        public virtual async Task<List<TDTO>> ListAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return autoMapper.Map<List<TEntity>, List<TDTO>>(await baseRepo.ListAsync(specification, cancellationToken));
        }
        /// <inheritdoc/>
        public virtual async Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> specification, CancellationToken cancellationToken = default)
        {
            return await baseRepo.ListAsync(specification, cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task<int> CountAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await baseRepo.CountAsync(specification, cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await baseRepo.CountAsync(cancellationToken);
        }
        /// <inheritdoc/>
        public virtual async Task<bool> AnyAsync(ISpecification<TEntity> specification, CancellationToken cancellationToken = default)
        {
            return await baseRepo.AnyAsync(specification, cancellationToken);
        }
       
    }
}
