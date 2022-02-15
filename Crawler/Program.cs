namespace Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleService service = new ConsoleService();

            var url = service.ReadLine();
            var app = new CrawlerLogic();

            app.Parse(url);
        }
    }
}
