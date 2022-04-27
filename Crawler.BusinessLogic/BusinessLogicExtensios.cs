using Crawler.BusinessLogic.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Crawler.BusinessLogic.Extensions
{
    public static class BusinessLogicExtensios
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<DbWorker>();
            services.AddScoped<Evaluator>();
            
            return services;
        }
    }
}
