using Crawler.BusinessLogic.Service;
using Crawler.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Crawler.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbWorker _dbWorker;

        public HomeController(DbWorker dbWorker)
        {
            _dbWorker = dbWorker;
        }

        public async Task<ViewResult> Index(int pg)
        {
            var countTests = await _dbWorker.GetCountTestResult();
            var tests = new TestResult() 
            { 
                Tests = await _dbWorker.GetTestResult(pg), 
                PageNumber = pg,
                PageSize = 5, 
                TotalItems = countTests 
            };

            tests.PageNumber += tests.PageSize;

            return View(tests);
        }
    }
}
