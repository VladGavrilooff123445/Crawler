using Crawler.BusinessLogic.Service;
using Crawler.Logic.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Crawler.BusinessLogic.Extensions
{
    public static class BusinessLogicExtensios
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<DbWorker>();
            services.AddScoped<Evaluator>();
            services.AddScoped<ResultEvaluate>();
            services.AddCrawlerLogic();
            services.AddScoped<Stopwatch>();

            return services;
        }
    }
}
