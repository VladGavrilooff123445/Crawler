using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using Crawler.Data;


namespace Crawler.EntityFramework
{
    public class CrawlerDbContext : DbContext, IEfRepositoryDbContext
    {
        public CrawlerDbContext(DbContextOptions<CrawlerDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Link> Links { get; set; }
        public DbSet<Test> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrawlerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
