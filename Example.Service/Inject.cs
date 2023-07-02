using EF.Turbo.Service.Core.Interfaces;
using Example.Repo.Core.Entity;
using Example.Repo.Core;
using Example.Service.Core.DTOs;
using Example.Service.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;
using Example.Service.Core.Services;
using EF.Turbo.Service;
using Example.Repo;

namespace Example.Service
{
    public static class Inject
    {
        public static IServiceCollection AddServiceModule(this IServiceCollection services)
        {
            services.AddExampleRepoModule();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IBaseService<ExampleDbContext, PersonEntity, PersonDTO>, PersonService>();
            services.AddScoped<IOrganizationService, OrganizationService>();
            services.AddServiceHelperFactories();
            return services;
        }
    }
}
