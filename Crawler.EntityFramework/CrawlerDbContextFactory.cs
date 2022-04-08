using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Crawler.EntityFramework
{
    public class CrawlerDbContextFactory : IDesignTimeDbContextFactory<CrawlerDbContext>
    {
        public CrawlerDbContext CreateDbContext(string[] args)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<CrawlerDbContext>();

            if(args.Length < 1 || string.IsNullOrEmpty(args[0]))
            {
                throw new ArgumentException(
                    "Invalid connection. Use CLI command -> dotnet ef database update -- \"connection your string\"" );
            }

            optionsBuilder.UseSqlServer(args[0]);

            return new CrawlerDbContext(optionsBuilder.Options);
        }
    }
}
