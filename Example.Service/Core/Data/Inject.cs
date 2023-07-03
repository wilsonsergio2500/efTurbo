using EF.Turbo.Repo.Core.Interfaces;
using Example.Service.Core.Data.Entity;
using Example.Service.Core.Data.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Service.Core.Data
{
    public static class Inject
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepo<ExampleDbContext, PersonEntity>, PersonRepo>();
            return services;
        }
    }
}
