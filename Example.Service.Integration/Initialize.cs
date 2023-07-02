using Example.Repo.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Example.Repo;
using System.Diagnostics;

namespace Example.Service.Integration
{
    public class Initialize
    {
        public static ServiceProvider? serviceProvider;

        public static void InitializeIoc()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<ExampleDbContext>(options => options.UseSqlServer("Data Source=20.241.3.231\\FPT;Initial Catalog=Reach;User ID=newlogin2;Password=test123$")
            .LogTo(message => Debug.WriteLine(message))
            );
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
