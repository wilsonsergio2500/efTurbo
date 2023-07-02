using EF.Turbo.Service.Core.Interfaces;
using EF.Turbo.Service.Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace EF.Turbo.Service
{
    public static class Inject
    {
        public static IServiceCollection AddServiceHelperFactories(this IServiceCollection services)
        {
            services.AddScoped<IFireNdForget, FireNdForget>();
            return services;
        }
    }
}
