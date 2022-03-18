using Crawler.Logic.Controler;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Crawler.ConsoleApplication
{
    public class ConsoleApp
    {
        private readonly ConsoleService _service;
        private ICrawlerLogic _crawlerLogic;

        public ConsoleApp(ICrawlerLogic crawlerLogic)
        {
            _crawlerLogic = crawlerLogic;
            _service = new ConsoleService();
        }
        public async Task Run()
        {
            var url = _service.ReadLine();
            var linksHtml = await _crawlerLogic.StartCrawlingByHtml(url);

            _service.WriteLine(linksHtml.Count.ToString());

            GetAllLinks(linksHtml);

            var linksXml = await _crawlerLogic.StartCrawlingByXml(url);

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
