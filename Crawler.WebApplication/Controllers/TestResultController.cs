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
            return View(new LinkResult() { Links = await _dbWorker.GetTestUrlsById(id) });
        }
    }
}
