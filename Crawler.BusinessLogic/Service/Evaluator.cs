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

        public Evaluator(HtmlCrawling htmlCrawling, XmlCrawling xmlCrawling, DbWorker dbWorker)
        {
            _htmlCrawling = htmlCrawling;
            _xmlCrawling = xmlCrawling;
            _dbWorker = dbWorker;
        }

        public async Task<List<Link>> PerformSiteMapLinks(string url)
        {
            var linksXml = await _xmlCrawling.SiteMapCrawling(url);

            return linksXml;
        }

        public async Task<List<Link>> PerformWebPageLinks(string url)
        {
            var linksHtml = await _htmlCrawling.CrawlingByHtml(url);

            return linksHtml;
        }

        public async Task SaveResultToDataBase(List<Link> links, string url, DateTime date)
        {
            await _dbWorker.SetDataToDb(links, date, url);
        }
    }
}
