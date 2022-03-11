using System.Collections.Generic;
using System.Linq;

namespace Crawler
{
    public class CrawlerLogic
    {
        private readonly WebService _webService;
        private readonly HtmlParser _htmlParser;
        private readonly XmlParser _xmlParser;

        public CrawlerLogic()
        {
            _webService = new WebService();
            _htmlParser = new HtmlParser();
            _xmlParser = new XmlParser();
        }

        public List<string> StartCrawling(string url)
        {
            HtmlCrawling htmlCrawling = new HtmlCrawling(_htmlParser, _webService);
            XmlCrawling xmlCrawling = new XmlCrawling(_xmlParser, _webService);

            var resultHtml = htmlCrawling.CrawlingByHtml(url);
            var resultXml = xmlCrawling.SiteMapCrawling(url);

            resultXml.AddRange(resultHtml);

            var result = resultXml.Distinct().ToList();

            return result;
        }
    }
}
