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

        public async Task<ViewResult> Index(int pageSize = 5, int numberOfPage = 1)
        {
            var countTests = await _dbWorker.GetCountTestResult();
            var tests = new TestResult() 
            { 
                Tests = await _dbWorker.GetTestResult(numberOfPage, pageSize), 
                PageNumber = numberOfPage,
                PageSize = pageSize, 
                TotalItems = countTests 
            };

            tests.PageNumber += 1;

            return View(tests);
        }
    }
}
