using Crawler.Logic.Model;
using Crawler.Logic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crawler.ConsoleApplication.Service
{
    public class ConsoleApp
    {
        private readonly ConsoleService _service;
        private readonly ConsoleResult _consoleResult;
        private readonly HtmlCrawling _htmlCrawling;
        private readonly XmlCrawling _xmlCrawling;


        public ConsoleApp(ConsoleService service, ConsoleResult consoleResult, HtmlCrawling htmlCrawling, XmlCrawling xmlCrawling)
        {
            _xmlCrawling = xmlCrawling;
            _htmlCrawling = htmlCrawling;
            _consoleResult = consoleResult; 
            _service = service;   
        }

        public async Task Run()
        {
            DateTime date = DateTime.Now;
            var url = _service.ReadLine();
            var linksHtml = await _htmlCrawling.CrawlingByHtml(url);
            var linksXml = await _xmlCrawling.SiteMapCrawling(url);

            _service.WriteLine("\n Unique links from sitemap: \n");

            var uniqHtml = _consoleResult.GetUniqueLinks(linksHtml, linksXml);
            GetAllLinks(uniqHtml);

            _service.WriteLine("\n Unique links from web page: \n");

            var uniqXml = _consoleResult.GetUniqueLinks(linksXml, linksHtml);
            GetAllLinks(uniqXml);

            _service.WriteLine("\n All links from sitemap and web page: \n");            

            var allLinks = _consoleResult.GetAllLinksFromSite(linksHtml, linksXml);
            GetAllLinks(allLinks);

            _service.WriteLine("Saving result");

            Environment.Exit(0);
        }

        private void GetAllLinks(List<Link> links)
        {
            var count = 1;  

            foreach (var link in links)
            {
                if(count == links.Count())
                {
                    _service.WriteLine($"{count}) {link.Url} - {link.Time} \n");
                    continue;
                }

                _service.WriteLine($"{count}) {link.Url} - {link.Time}");
                count++;
            }
        }
    }
}
