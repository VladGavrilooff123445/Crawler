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

        public async Task<ViewResult> Index()
        {
            return View(new TestResult { Tests = await _dbWorker.GetAllTestResult()});
        }
       
    }
}
