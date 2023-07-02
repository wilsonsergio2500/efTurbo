using EF.Turbo.Repo.Core.Entity;
using EF.Turbo.Repo.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EF.Turbo.Service.Core.Interfaces
{
    public interface IFireNdForget
    {
        /// <summary>
        /// The targeted Repo Service <see cref="IBaseRepo{TDbContext, TEntity}" /> <typeparamref name="TRepoService"/>,
        /// The Entity Framework context shared by the Repo <typeparamref name="TDbContext"/>.
        /// The Concrete Entity Type for the Repo <typeparamref name="TEntity"/>.
        /// </summary>
        /// <typeparam name="TDbContext">EF (DbContext)</typeparam>
        /// <typeparam name="TEntity">The Entity Type</typeparam>
        /// <typeparam name="TEntity">The Entity Type</typeparam>
        /// <param name="repoWork">The Fire and ForgetFunction that targets a given repo</param>
        void Execute<TRepoService, TDbContext, TEntity>(Func<TRepoService, Task> repoWork)
           where TRepoService : IBaseRepo<TDbContext, TEntity> where TDbContext : DbContext where TEntity : BaseEntity;
    }
}
