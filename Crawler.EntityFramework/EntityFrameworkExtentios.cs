using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Crawler.EntityFramework.Extentions
{
    public static class EntityFrameworkExtentios
    {
        public static IServiceCollection AddEntityFramework(this IServiceCollection services)
        {
            services.AddEfRepository<CrawlerDbContext>(options => options.UseSqlServer(@"Server=web.ukad.dev\SQL2019;Database=ukad-webcrawler-trainee; user id=ukad-webcrawler-trainee; password=f3h6FU4vkjPvpjzf;"));
            services.AddScoped<CrawlerDbContextFactory>();

            return services;
        }
    }
}
