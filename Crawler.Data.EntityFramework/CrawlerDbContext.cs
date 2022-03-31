using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using WebCrawler.Data;


namespace Crawler.Data.EntityFramework
{
    public class CrawlerDbContext : DbContext, IEfRepositoryDbContext
    {
        public WebCrawlerDbContext(DbContextOptions<CrawlerDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrawlerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
