using Crawler.BusinessLogic.Service;
using Crawler.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Crawler.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbWorker _dbWorker;
        private TestResult _tests; 

        public HomeController(DbWorker dbWorker)
        {
            _tests = new TestResult();
            _dbWorker = dbWorker;
        }

        public async Task<ViewResult> Index(int pg)
        {
            

            _tests.Tests = await _dbWorker.GetTestResult(pg);
            pg += 5;
            _tests.ShowedTest += pg;


            return View(_tests);
        }
    }
}
