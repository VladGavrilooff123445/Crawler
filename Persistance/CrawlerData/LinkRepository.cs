using System.Data;
using Application.Interfaces;
using Persistance.CrawlerEntity;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance.CrawlerData
{
    public class LinkRepository : ILinkRepository
    {
        protected readonly CrawlerDbContext _context;

        public LinkRepository(CrawlerDbContext context)
        {
            _context = context;
        }

        public async Task SetDataToDb(IEnumerable<Application.Model.Link> links, DateTime date, string url)
        {
            var newTest = new Test { Url = url, Date = date };
            await _context.Test.AddAsync(newTest);
            await _context.SaveChangesAsync();

            _context.Link.AddRange(links
                .Select(p => new Link()
                {
                    Url = p.Url,
                    Time = p.Time,
                    InSitemap = p.InSitemap,
                    InWebSite = p.InWebSite,
                    TestId = newTest.Id,
                    Test = newTest
                }));

            await _context.SaveChangesAsync();
        }

        public async Task<int> GetCountTestResult()
        {
            var result = await _context.Set<Test>().CountAsync();

            return result;
        }

        public async Task<IReadOnlyList<Test>> GetTestResult(int amountOfPage, int pageSize)
        {
            return await _context
                .Set<Test>()
                .Skip(amountOfPage * pageSize)
                .Take(pageSize)
                .ToListAsync();                   
        }

        public async Task<IReadOnlyList<Link>> GetTestUrlsById(int id)
        {
            return await _context
                 .Set<Link>()
                 .Where(a => a.TestId == id)
                 .OrderBy(a => a.Time)
                 .ToListAsync();
        }
    }
}
