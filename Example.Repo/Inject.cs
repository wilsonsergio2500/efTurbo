using EF.Turbo.Repo.Core.Interfaces;
using Example.Repo.Core;
using Example.Repo.Core.Entity;
using Example.Repo.Core.Repos;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Repo
{
    public static class Inject
    {
        public static IServiceCollection AddExampleRepoModule(this IServiceCollection services)
        {
            services.AddScoped<IBaseRepo<ExampleDbContext, PersonEntity>, PersonRepo>();
            services.AddScoped<IOrganizationRepo, OrganizationRepo>();
            return services;
        }
    }
}
