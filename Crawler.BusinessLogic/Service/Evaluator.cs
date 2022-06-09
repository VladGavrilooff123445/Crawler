using Crawler.Logic.Service;
using Crawler.Logic.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.BusinessLogic.Service
{
    public class Evaluator
    {
        private readonly HtmlCrawling _htmlCrawling;
        private readonly XmlCrawling _xmlCrawling;
        private readonly DbWorker _dbWorker;
        private readonly DataWorker _result;

        public Evaluator(HtmlCrawling htmlCrawling, XmlCrawling xmlCrawling, DbWorker dbWorker,  DataWorker result)
        { 
            _result = result;   
            _htmlCrawling = htmlCrawling;
            _xmlCrawling = xmlCrawling;
            _dbWorker = dbWorker;
        }

        public async Task<IEnumerable<Link>> CrawlingUrl(string url)
        {
            DateTime date = DateTime.Now;
            var linksHtml = await _htmlCrawling.CrawlingByHtml(url);
            var linksXml = await _xmlCrawling.SiteMapCrawling(url);

            _result.GetUniqueLinks(linksHtml, linksXml);

            var allLinks = await _result.GetAllLinksForDb(linksHtml, linksXml);

            await SaveResultToDataBase(allLinks, url, date);

            return allLinks;
        }

        

        private async Task SaveResultToDataBase(IEnumerable<Link> links, string url, DateTime date)
        {
            await _dbWorker.SetDataToDb(links, date, url);
        }
    }
}
