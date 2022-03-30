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
        private readonly HtmlCrawling _htmlCrawling;
        private readonly XmlCrawling _xmlCrawling;
        private readonly ConsoleResult _consoleResult;


        public ConsoleApp(ConsoleService service, HtmlCrawling htmlCrawling, XmlCrawling xmlCrawling, ConsoleResult consoleResult)
        {
            _consoleResult = consoleResult; 
            _xmlCrawling = xmlCrawling;
            _htmlCrawling = htmlCrawling;
            _service = service;   
        }

        public async Task Run()
        {
            var url = _service.ReadLine();
            var linksHtml = await _htmlCrawling.CrawlingByHtml(url);
            var linksXml = await _xmlCrawling.SiteMapCrawling(url);

            _service.WriteLine("\n Unique links from web page: \n");

            var uniqHtml = _consoleResult.GetUniqueLinks(linksHtml, linksXml);
            GetAllLinks(uniqHtml);

            _service.WriteLine("\n Unique links from sitemap: \n");

            var uniqXml = _consoleResult.GetUniqueLinks(linksXml, linksHtml);
            GetAllLinks(uniqXml);

            _service.WriteLine("\n All links from sitemap and web page: \n");

            var allLinks = _consoleResult.GetAllLinksFromSite(linksHtml, linksXml);
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
