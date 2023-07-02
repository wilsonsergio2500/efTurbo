using Example.Repo.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    => CreateHostBuilder(args).Build().Run();
    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                // uncomment if testing with a real database
                //services.AddDbContext<ExampleDbContext>(options => options.UseSqlServer(""));
            });

}
