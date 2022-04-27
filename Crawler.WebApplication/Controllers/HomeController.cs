using Crawler.BusinessLogic.Service;
using Crawler.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Crawler.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbWorker _dbWorker;
        private readonly Evaluator _evaluator;

        public HomeController(DbWorker dbWorker, Evaluator evaluator)
        {
            _evaluator = evaluator;
            _dbWorker = dbWorker;
        }

        public async Task<ViewResult> Index(int pageSize = 5, int numberOfPage = 0)
        {
            var countTests = await _dbWorker.GetCountTestResult();
            var tests = new TestResult()
            {
                Tests = await _dbWorker.GetTestResult(numberOfPage, pageSize),
                PageNumber = numberOfPage,
                PageSize = pageSize,
                TotalItems = countTests
            };

            return View(tests);
        }

        public async Task GetNewTest(InputUrl input)
        {
            await _evaluator.CrawlingUrl(input.Url);
        }
    }
}
