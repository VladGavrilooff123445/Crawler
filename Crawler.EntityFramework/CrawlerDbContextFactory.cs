using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Crawler.EntityFramework
{
    public class CrawlerDbContextFactory : IDesignTimeDbContextFactory<CrawlerDbContext>
    {
        public CrawlerDbContext CreateDbContext(string[] args)
        {
            var conect = @"Server=web.ukad.dev\SQL2019;Database=ukad-webcrawler-trainee; user id=ukad-webcrawler-trainee; password=f3h6FU4vkjPvpjzf;";
            var optionsBuilder = new DbContextOptionsBuilder<CrawlerDbContext>();

            optionsBuilder.UseSqlServer(conect);

            return new CrawlerDbContext(optionsBuilder.Options);
        }
    }
}
