using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using Example.Service.Core.Data;

namespace Example.Service.Integration
{
    public class Initialize
    {
        public static ServiceProvider? serviceProvider;

        public static void InitializeIoc()
        {
            IServiceCollection services = new ServiceCollection();

            //services.AddDbContext<ExampleDbContext>(options => options.UseSqlServer("").LogTo(message => Debug.WriteLine(message)));
            services.AddDbContext<ExampleDbContext>(options => options.UseInMemoryDatabase("integration-db"));
            services.AddServiceModule();

            serviceProvider = services.BuildServiceProvider();
        }
        public static class IoC
        {
            public static T GetService<T>()
            {
                ServiceProvider? serviceProvider = Initialize.serviceProvider;
                if (serviceProvider is not null)
                {
                    T? service = serviceProvider.GetService<T>();
                    if (service is not null)
                    {
                        return service;
                    }
                }

                throw new InvalidOperationException($"{nameof(T)} service not found");
            }
        }
    }
}
