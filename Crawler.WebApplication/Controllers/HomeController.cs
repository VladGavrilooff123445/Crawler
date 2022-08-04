using Crawler.WebApplication.Models;
using Crawler.WebApplication.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Crawler.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestsService _getTests;

        public HomeController(TestsService getTests)
        {
            _getTests = getTests;
        }
        /// <summary>
        /// Get all tests from database
        /// </summary>
        /// <param name="tests"></param>
        /// <returns></returns>
        public async Task<ViewResult> Index(TestResult tests)
        {  
            return View(await _getTests.GetListOfTests(tests));
        }

        /// <summary>
        /// Return updated list of tests with new test 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<ViewResult> GetNewTest(InputUrl input)
        {
            return View("Index", await _getTests.GetNewTestItem(input.Url));
        }
    }
}
