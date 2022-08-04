using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Application.BussinessLogic;
using Application.Interfaces;
using Application.Services;
using Persistance.CrawlerData;
using Persistance.CrawlerEntity;

namespace InfrastructureIoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<LinkCrawler>();
            services.AddScoped<HtmlCrawling>();
            services.AddScoped<HtmlParser>();
            services.AddScoped<TimeEvaluate>();
            services.AddScoped<Validator>();
            services.AddScoped<WebService>();
            services.AddScoped<XmlCrawling>();
            services.AddScoped<XmlParser>();
            services.AddScoped<LinkRepository>();
            services.AddScoped<Domain.Link>();
            services.AddScoped<Domain.Test>();
            services.AddScoped<Domain.Link>();
            services.AddScoped<Domain.Test>();
            services.AddScoped<ILinkRepository, LinkRepository>();
        }

        public static void RegisterDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CrawlerDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
