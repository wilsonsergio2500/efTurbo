using EF.Turbo.Repo.Core.Entity;
using EF.Turbo.Repo.Core.Interfaces;
using EF.Turbo.Service.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EF.Turbo.Service.Core.Service
{
    /// <inheritdoc cref="IFireNdForget"/>
    public class FireNdForget : IFireNdForget
    {
        readonly IServiceScopeFactory serviceScopeFactory;
        public FireNdForget(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        /// <inheritdoc/>
        public void Execute<TRepoService, TDbContext, TEntity>(Func<TRepoService, Task> repoWork)
           where TRepoService : IBaseRepo<TDbContext, TEntity> where TDbContext : DbContext where TEntity : BaseEntity
        {
            Task.Run(async () =>
            {
                try
                {
                    using IServiceScope scope = serviceScopeFactory.CreateScope();
                    TRepoService? repo = scope.ServiceProvider.GetService<TRepoService>();
                    if (repo is TRepoService repoService)
                    {
                        await repoWork(repoService);
                    }
                }
                catch
                {

                }

            });

        }
    }
}
