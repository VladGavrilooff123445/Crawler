using Crawler.Logic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Crawler.ConsoleApplication
{
    public class ConsoleApp
    {
        private readonly ConsoleService _service;
        private readonly CrawlerLogic _crawlerLogic;
        
        public ConsoleApp(CrawlerLogic crawlerLogic, ConsoleService service)
        {
            _service = service;
            _crawlerLogic = crawlerLogic;
        }

        public async Task Run()
        {
            var url = _service.ReadLine();
            var linksHtml = await _crawlerLogic.StartCrawlingByHtml(url);
            var linksXml = await _crawlerLogic.StartCrawlingByXml(url, linksHtml);

            _service.WriteLine("\n Unique links from web page: \n");

            var uniqHtml = _crawlerLogic.GetUniqueLinksFromHtml(linksHtml, linksXml);
            GetAllLinks(uniqHtml);

            _service.WriteLine("\n Unique links from sitemap: \n");

            var uniqXml = _crawlerLogic.GetUniqueLinksFromXml(linksHtml, linksXml);
            GetAllLinks(uniqXml);

            _service.WriteLine("\n All links from sitemap and web page: \n");

            var allLinks = _crawlerLogic.GetAllLinksFromSite(linksHtml, linksXml);
            GetAllLinks(allLinks);

            Environment.Exit(0);
        }

        private void GetAllLinks(List<string> links)
        {
            var count = 1;  

            foreach (var link in links)
            {
                if(count == links.Count())
                {
                    _service.WriteLine($"{count}) {link} \n");
                    continue;
                }

                _service.WriteLine($"{count}) {link}");
                count++;
            }
        }
    }
}
