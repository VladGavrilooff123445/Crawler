using Application.CrawlerLogic;
using Infrastucture.CrawlerData;

namespace Application.BusinessLogic.Service
{
    public class Evaluator
    {
        private readonly HtmlCrawling _htmlCrawling;
        private readonly XmlCrawling _xmlCrawling;
        private readonly DbWorker _dbWorker;
        private readonly DataWorker _worker;

        public Evaluator(HtmlCrawling htmlCrawling, XmlCrawling xmlCrawling, DbWorker dbWorker,  DataWorker worker)
        { 
            _worker = worker;   
            _htmlCrawling = htmlCrawling;
            _xmlCrawling = xmlCrawling;
            _dbWorker = dbWorker;
        }

        public async Task<IEnumerable<CrawlerLogic.Link>> CrawlingUrl(string url)
        {
            DateTime date = DateTime.Now;
            var linksHtml = await _htmlCrawling.CrawlingByHtml(url);
            var linksXml = await _xmlCrawling.SiteMapCrawling(url);

            var allLinks = _worker.GetAllLinksForDb(linksHtml, linksXml);

            await SaveResultToDataBase(allLinks, url, date);

            return allLinks;
        }

        

        private async Task SaveResultToDataBase(IEnumerable<CrawlerLogic.Link> links, string url, DateTime date)
        {
            await _dbWorker.SetDataToDb(links, date, url);
        }
    }
}
