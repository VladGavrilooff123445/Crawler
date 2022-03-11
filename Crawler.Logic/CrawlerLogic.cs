using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crawler
{
    public class CrawlerLogic
    {
        private readonly WebService _webService;
        private readonly HtmlParser _htmlParser;
        private readonly XmlParser _xmlParser;
        private readonly Validator _validator;

        public CrawlerLogic()
        {
            _validator = new Validator();
            _webService = new WebService();
            _htmlParser = new HtmlParser(_validator);
            _xmlParser = new XmlParser();
        }

        public async Task<List<string>> StartCrawling(string url)
        {
            HtmlCrawling htmlCrawling = new HtmlCrawling(_htmlParser, _webService);
            XmlCrawling xmlCrawling = new XmlCrawling(_xmlParser, _webService);

            var resultHtml = await htmlCrawling.CrawlingByHtml(url);
            var resultXml = await xmlCrawling.SiteMapCrawling(url);

            resultXml.AddRange(resultHtml);

            var result = resultXml.Distinct().ToList();

            return result;
        }
    }
}
