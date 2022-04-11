using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crawler.EntityFramework.Extentions
{
    public static class EntityFrameworkExtentios
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, string connectionString)
        {
            services.AddEfRepository<CrawlerDbContext>(options => options.UseSqlServer(@$"{connectionString}"));
            services.AddScoped<CrawlerDbContextFactory>();

            return services;
        }
    }
}
