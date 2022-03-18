using Crawler.Logic;
using Crawler.Logic.Controler;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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
                        services.AddScoped<ICrawlerLogic, CrawlerLogic>();
                        services.AddScoped<ConsoleApp>();
                        services.AddScoped<HtmlCrawling>();
                        services.AddScoped<XmlCrawling>();
                        services.AddScoped<HtmlParser>();
                        services.AddScoped<XmlParser>();
                        services.AddScoped<Validator>();
                        services.AddScoped<WebService>();
                    }).ConfigureLogging(options => options.SetMinimumLevel(LogLevel.Error));
    }

}
