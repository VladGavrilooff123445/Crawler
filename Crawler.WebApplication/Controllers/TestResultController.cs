using Microsoft.AspNetCore.Mvc;
using Crawler.WebApplication.Models;
using Crawler.BusinessLogic.Service;
using System.Threading.Tasks;

namespace Crawler.WebApplication.Controllers
{
    public class TestResultController : Controller
    {
        private readonly DbWorker _dbWorker;

        public TestResultController(DbWorker dbWorker)
        {
            _dbWorker = dbWorker;
        }

        public async Task<ViewResult> LinkResult(int id)
        {
            var testUrl = await _dbWorker.GetTestUrlsById(id);
            var allTestLinks = await _dbWorker.GetAllTestLinksById(id);
            var inSitemap = await _dbWorker.GetOnlySitemapLinks(id);
            var inWebsite = await _dbWorker.GetOnlyWebsiteLinks(id);

            return View(new LinkResult() { Url = testUrl, OnlyInSitemap = inSitemap, OnlyInWebsite = inWebsite, Links = allTestLinks });
        }
    }
}
