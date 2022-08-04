using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastucture.CrawlerEntity.Extensions
{
    public static class EntityFrameworkExtensios
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, string connectionString)
        {
           //services.AddEfRepository<CrawlerDbContext>(options => options.UseSqlServer(@$"{connectionString}"));
            return services;
        }
    }
}
