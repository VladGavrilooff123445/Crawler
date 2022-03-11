using System.Threading.Tasks;

namespace Crawler.ConsoleApplication
{
    public class ConsoleApp
    {

      public async Task Run()
      {
            ConsoleService service = new ConsoleService();

            var url = service.ReadLine();
            var app = new CrawlerLogic();

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
