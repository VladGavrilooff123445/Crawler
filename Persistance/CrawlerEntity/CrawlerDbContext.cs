using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistance.CrawlerEntity
{
    public class CrawlerDbContext : DbContext
    {
        public CrawlerDbContext(DbContextOptions<CrawlerDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Domain.Link> Link { get; set; }
        public DbSet<Domain.Test> Test { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CrawlerDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
