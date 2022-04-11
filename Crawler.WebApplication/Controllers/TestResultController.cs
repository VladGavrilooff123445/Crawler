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
            var TestUrl = await _dbWorker.GetTestUrlsById(id);
            var allTestLinks = await _dbWorker.GetAllTestLinksById(id);
            var InSitemap = await _dbWorker.GetOnlySitemapLinks(id);
            var InWebsite = await _dbWorker.GetOnlySitemapLinks(id);

            return View(new LinkResult() { Url = TestUrl, OnlyInSitemap = InSitemap, OnlyInWebsite = InWebsite, Links = allTestLinks });
        }
    }
}
