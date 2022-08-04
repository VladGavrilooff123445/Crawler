using Application.Interfaces;
using Application.BussinessLogic;
using Crawler.WebApplication.Models;
using System.Threading.Tasks;

namespace Crawler.WebApplication.Services
{
    public class TestsService
    {
        private readonly ILinkRepository _repository;
        private readonly LinkCrawler _linkCrawler;

        public TestsService(ILinkRepository repository, LinkCrawler linkCrawler)
        {
            _repository = repository;
            _linkCrawler = linkCrawler;
        }

        public async Task<TestResult> GetListOfTests(TestResult tests)
        {
            var countTests = await _repository.GetCountTestResult();

            tests.Tests = await _repository.GetTestResult(tests.PageNumber, tests.PageSize);
            tests.TotalItems = countTests;

            return tests;
        }

        public async Task<TestResult> GetNewTestItem(string url)
        {
            var tests = new TestResult();

            await _linkCrawler.CrawlingUrl(url);

            var countTests = await _repository.GetCountTestResult();

            tests.Tests = await _repository.GetTestResult(tests.PageNumber, tests.PageSize);
            tests.TotalItems = countTests;

            return tests;
        }
    }
}
