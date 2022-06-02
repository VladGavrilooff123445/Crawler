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
        private readonly ResultEvaluate _result;

        public Evaluator(HtmlCrawling htmlCrawling, XmlCrawling xmlCrawling, DbWorker dbWorker, ResultEvaluate result)
        { 
            _result = result;   
            _htmlCrawling = htmlCrawling;
            _xmlCrawling = xmlCrawling;
            _dbWorker = dbWorker;
        }

        public async Task<List<Link>> CrawlingUrl(string url)
        {
            DateTime date = DateTime.Now;
            var linksHtml = await _htmlCrawling.CrawlingByHtml(url);
            var linksXml = await _xmlCrawling.SiteMapCrawling(url, linksHtml);

            var allLinks = await _result.GetAllLinksFromSite(linksHtml, linksXml);

            await SaveResultToDataBase(allLinks, url, date);

            return allLinks;
        }

        

        private async Task SaveResultToDataBase(List<Link> links, string url, DateTime date)
        {
            await _dbWorker.SetDataToDb(links, date, url);
        }
    }
}
