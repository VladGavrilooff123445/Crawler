using Crawler.Logic.Service;
using Crawler.Logic.Model;
using Crawler.ConsoleApplication.Service;
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
        private readonly ConsoleService _service;
        private readonly ConsoleResult _consoleResult;

        public Evaluator(HtmlCrawling htmlCrawling, XmlCrawling xmlCrawling, DbWorker dbWorker, ConsoleService service, ConsoleResult consoleResult)
        {
            _consoleResult = consoleResult;
            _service = service; 
            _htmlCrawling = htmlCrawling;
            _xmlCrawling = xmlCrawling;
            _dbWorker = dbWorker;
        }



        public async Task CrawlingUrl(string url)
        {
            DateTime date = DateTime.Now;
            var linksHtml = await _htmlCrawling.CrawlingByHtml(url);
            var linksXml = await _xmlCrawling.SiteMapCrawling(url);

            _service.WriteLine("\n Unique links from sitemap: \n");

            var uniqHtml = _consoleResult.GetUniqueLinks(linksHtml, linksXml);
            

            _service.WriteLine("\n Unique links from web page: \n");

            var uniqXml = _consoleResult.GetUniqueLinks(linksXml, linksHtml);
            

            _service.WriteLine("\n All links from sitemap and web page: \n");

            var allLinks = _consoleResult.GetAllLinksFromSite(linksHtml, linksXml);
            

            _service.WriteLine("Saving result");

            await SaveResultToDataBase(allLinks, url, date);
        }

        private async Task SaveResultToDataBase(List<Link> links, string url, DateTime date)
        {
            await _dbWorker.SetDataToDb(links, date, url);
        }
    }
}
