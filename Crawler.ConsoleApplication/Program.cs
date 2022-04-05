using Crawler.Logic.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Diagnostics;
using Crawler.EntityFramework;

namespace Crawler.ConsoleApplication
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
                        services.AddEfRepository<CrawlerDbContext>(options => options.UseSqlServer(@"Server=web.ukad.dev\\SQL2019;Database=ukad-webcrawler-trainee; user id=ukad-webcrawler-trainee; password=f3h6FU4vkjPvpjzf;"));
                        services.AddScoped<CrawlerDbContextFactory>();
                        services.AddScoped<TimeEvaluate>();
                        services.AddScoped<ConsoleService>();
                        services.AddScoped<ConsoleApp>();
                        services.AddScoped<HtmlCrawling>();
                        services.AddScoped<XmlCrawling>();
                        services.AddScoped<HtmlParser>();
                        services.AddScoped<XmlParser>();
                        services.AddScoped<Validator>();
                        services.AddScoped<WebService>();
                        services.AddScoped<TimeResponse>();
                        services.AddScoped<Stopwatch>();
                        services.AddScoped<ConsoleResult>();
                    }).ConfigureLogging(options => options.SetMinimumLevel(LogLevel.Error));
    }

}
