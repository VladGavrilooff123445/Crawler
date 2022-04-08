using Crawler.BusinessLogic.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Crawler.BusinessLogic.Extentions
{
    public static class BusinessLogicExtentios
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<DbWorker>();
            services.AddScoped<Evaluator>();
            
            return services;
        }
    }
}
