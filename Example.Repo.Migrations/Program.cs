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
                services.AddDbContext<ExampleDbContext>(options => options.UseSqlServer("Data Source=20.241.3.231\\FPT;Initial Catalog=Reach;User ID=newlogin2;Password=test123$"));
            });

}
