using Microsoft.AspNetCore.Mvc;
using Crawler.WebApplication.Services;
using System.Threading.Tasks;

namespace Crawler.WebApplication.Controllers
{
    public class TestResultController : Controller
    {
        private readonly LinksService _getLinks;

        public TestResultController(LinksService getLinks)
        {
            _getLinks = getLinks;
        }
        /// <summary>
        /// Return the list of links by TestId 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ViewResult> LinkResult(int id)
        {   
            return View(await _getLinks.GetListOfLinks(id));
        }
    }
}
