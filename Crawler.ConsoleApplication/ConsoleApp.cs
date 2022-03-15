using System.Threading.Tasks;

namespace Crawler.ConsoleApplication
{
    public class ConsoleApp
    {

      public async Task Run()
      {
            WebService webService = new WebService();
            Validator validator = new Validator();
            HtmlParser htmlParser = new HtmlParser(validator);
            XmlParser xmlParser = new XmlParser();
            HtmlCrawling htmlCrawling = new HtmlCrawling(htmlParser, webService);
            XmlCrawling xmlCrawling = new XmlCrawling(xmlParser, webService);
            ConsoleService service = new ConsoleService();

            var url = service.ReadLine();
            var app = new CrawlerLogic(htmlCrawling, xmlCrawling);

            var links = await app.StartCrawling(url);

            service.WriteLine(links.Count.ToString());
            var i = 1;
            foreach (var link in links)
            {
                service.WriteLine($"{i})" + " " + link.ToString());
                i++;
            }
      }
        
    }
}
