using Crawler.Logic.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Crawler.Logic.Extensions
{
    public static class LogicExtensions
    {
        public static IServiceCollection AddCrawlerLogic(this IServiceCollection services)
        {
            services.AddScoped<WebService>();
            services.AddScoped<TimeResponse>();
            services.AddScoped<HtmlCrawling>();
            services.AddScoped<HtmlParser>();
            services.AddScoped<Validator>();
            services.AddScoped<XmlCrawling>();
            services.AddScoped<XmlParser>();
            services.AddScoped<TimeEvaluate>();

            return services;
        }
    }
}
