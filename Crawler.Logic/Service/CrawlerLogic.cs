using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crawler
{
    public class CrawlerLogic
    {
        private readonly HtmlCrawling _htmlCrawling;
        private readonly XmlCrawling _xmlCrawling;

        public CrawlerLogic(HtmlCrawling htmlCrawling, XmlCrawling xmlCrawling)
        {
            _htmlCrawling = htmlCrawling;
            _xmlCrawling = xmlCrawling;
        }

        public virtual async Task<List<string>> StartCrawling(string url)
        {
            var resultHtml = await _htmlCrawling.CrawlingByHtml(url);
            var resultXml = await _xmlCrawling.SiteMapCrawling(url);

            resultXml.AddRange(resultHtml);

            var result = resultXml.Distinct().ToList();

            return result;
        }
    }
}
