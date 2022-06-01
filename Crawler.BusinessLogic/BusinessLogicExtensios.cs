using Crawler.BusinessLogic.Service;
using Crawler.EntityFramework.Extensions;
using Crawler.Logic.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Crawler.BusinessLogic.Extensions
{
    public static class BusinessLogicExtensios
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services, string connectionString)
        {
            services.AddEntityFramework(connectionString);
            services.AddScoped<DbWorker>();
            services.AddScoped<Evaluator>();
            services.AddScoped<ResultEvaluate>();
            services.AddCrawlerLogic();
            services.AddScoped<Stopwatch>();

            return services;
        }
    }
}
