using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Diagnostics;
using Crawler.EntityFramework.Extentions;
using Crawler.Logic.Extentions;
using Crawler.BusinessLogic.Extentions;

namespace Crawler.ConsoleApplication.Service
{
    class Program
    {
       async static Task Main(string[] args)
       {
            using IHost host = CreateHostBuilder(args).Build();
            var app = host.Services.GetService<ConsoleApp>();
            
            await app.Run();
            await host.RunAsync();    
       }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((hostContext, services) =>
                    {
                        services.AddEntityFramework();
                        services.AddBusinessLogic();
                        services.AddScoped<ConsoleResult>();
                        services.AddScoped<ConsoleService>();
                        services.AddScoped<ConsoleApp>();
                        services.AddScoped<Stopwatch>();
                        services.AddCrawlerLogic();
                    }).ConfigureLogging(options => options.SetMinimumLevel(LogLevel.Error));
    }

}
