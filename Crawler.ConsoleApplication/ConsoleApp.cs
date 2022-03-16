using Crawler.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Crawler.ConsoleApplication
{
    public class ConsoleApp
    {
        private readonly ConsoleService _service;

        public ConsoleApp()
        {
            _service = new ConsoleService();
        }
        public async Task Run()
        {
            WebService webService = new WebService();
            Validator validator = new Validator();
            HtmlParser htmlParser = new HtmlParser(validator);
            XmlParser xmlParser = new XmlParser();
            HtmlCrawling htmlCrawling = new HtmlCrawling(htmlParser, webService);
            XmlCrawling xmlCrawling = new XmlCrawling(xmlParser, webService);

            var url = _service.ReadLine();
            var app = new CrawlerLogic(htmlCrawling, xmlCrawling);
            var linksHtml = await app.StartCrawlingByHtml(url);

            _service.WriteLine(linksHtml.Count.ToString());

            GetAllLinks(linksHtml);

            var linksXml = await app.StartCrawlingByXml(url);

            _service.WriteLine(linksXml.Count.ToString());

            GetAllLinks(linksXml);
        }
        

        private void GetAllLinks(List<string> links)
        {
            var count = 1;  

            foreach (var link in links)
            {
                _service.WriteLine($"{count.ToString()}) {link}");
                count++;
            }
        }
    }
}
