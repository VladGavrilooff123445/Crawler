﻿using System.Linq;

namespace Crawler.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleService service = new ConsoleService();

            var url = service.ReadLine();
            var app = new CrawlerLogic();

            var links = app.StartCrawling(url);

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
