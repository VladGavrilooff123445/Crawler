using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crawler.Logic
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

        public virtual async Task<List<string>> StartCrawlingByHtml(string url)
        {
            var resultHtml = await _htmlCrawling.CrawlingByHtml(url);    

            return resultHtml;
        }

        public virtual async Task<List<string>> StartCrawlingByXml(string url)
        {
            var resultXml = await _xmlCrawling.SiteMapCrawling(url);

            return resultXml;
        }
    }
}
