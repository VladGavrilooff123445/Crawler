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

        public async Task<ViewResult> Index(TestResult tests )
        {
            var countTests = await _dbWorker.GetCountTestResult();
            tests.Tests = await _dbWorker.GetTestResult(tests.PageNumber, tests.PageSize);           
            tests.TotalItems = countTests;
            

            return View(tests);
        }

        public async Task GetNewTest(InputUrl input)
        {
            await _evaluator.CrawlingUrl(input.Url);
        }
    }
}
