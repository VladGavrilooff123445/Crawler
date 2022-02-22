using System.Linq;

namespace Crawler.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleService service = new ConsoleService();

            var url = service.ReadLine();
            var app = new CrawlerLogic();

            var links = app.Parse(url);

            service.WriteLine(links.Count().ToString());

            foreach (var link in links)
            {
                service.WriteLine(link);
            }
        }
    }
}
