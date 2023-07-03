using EF.Turbo.Service.Core.Interfaces;
using Example.Service.Core.DTOs;
using Example.Service.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;
using Example.Service.Core.Services;
using EF.Turbo.Service;
using Example.Service.Core.Data;
using Example.Service.Core.Data.Entity;

namespace Example.Service
{
    public static class Inject
    {
        public static IServiceCollection AddServiceModule(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IBaseService<ExampleDbContext, PersonEntity, PersonDTO>, PersonService>();
            services.AddServiceHelperFactories();
            return services;
        }
    }
}
