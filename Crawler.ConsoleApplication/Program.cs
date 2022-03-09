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

            var siteMapLinks = app.SiteMapCrawling(url);

            service.WriteLine("links by using sitemap");

            foreach (var link in siteMapLinks)
            {
                service.WriteLine(link);
            }

            var links = app.StartCrawling(url);

            service.WriteLine(links.Count().ToString());
            foreach(var link in links)
            {
                service.WriteLine(link.ToString());
            }
        }
    }
}
