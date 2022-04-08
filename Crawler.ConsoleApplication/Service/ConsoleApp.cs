using System;
using Crawler.BusinessLogic.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawler.Logic.Model;

namespace Crawler.ConsoleApplication.Service
{
    public class ConsoleApp
    {
        private readonly ConsoleService _service;
        private readonly ConsoleResult _consoleResult;
        private readonly Evaluator _evaluator;
        
        
        public ConsoleApp(ConsoleService service, ConsoleResult consoleResult, Evaluator evaluator)
        {
            _evaluator = evaluator;
            _consoleResult = consoleResult; 
            _service = service;   
        }

        public async Task Run()
        {
            DateTime date = DateTime.Now;
            var url = _service.ReadLine();
            var linksHtml = await _evaluator.PerformWebPageLinks(url);
            var linksXml = await _evaluator.PerformSiteMapLinks(url);

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

            await _evaluator.SaveResultToDataBase(allLinks, url, date);

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
