using Example.Repo.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Repo.Integration
{
    public class Initialize
    {
        public static ServiceProvider? serviceProvider;
        public static void InitializeIoc()
        {
            IServiceCollection services = new ServiceCollection();

            //services.AddDbContext<ExampleDbContext>(options => options.UseSqlServer(""));
            services.AddDbContext<ExampleDbContext>(options => options.UseInMemoryDatabase("integration-db"));
            services.AddExampleRepoModule();

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
