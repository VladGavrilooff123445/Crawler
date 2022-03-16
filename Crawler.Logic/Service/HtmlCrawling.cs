using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Crawler.Logic
{
    public class HtmlCrawling
    {
        private readonly WebService _web;
        private readonly HtmlParser _parser;
        public HtmlCrawling(HtmlParser parser, WebService web)
        {
            _parser = parser;
            _web = web;
        }

        public virtual async Task<List<string>> CrawlingByHtml(string url)
        {
            List<Link> crawledLinks = new List<Link>();
            Link startLink = new Link() { Url = url };
            crawledLinks.Add(startLink);

            crawledLinks = await CrawlingLogic(crawledLinks);
            var result = crawledLinks
                .Select(a => a.Url + " - " + a.Timing.ToString())
                .ToList();

            return result;
        }

        private async Task<List<Link>> CrawlingLogic(List<Link> crawledLinks)
        {
            Stopwatch timer = new Stopwatch();
            var onlyOneElement = 1;

            timer.Start();

            while (crawledLinks.Any(a => a.IsCrawled == false))
            {
                var item = crawledLinks.First(a => a.IsCrawled == false);
                var html = await _web.GetHtmlAsString(item.Url);

                if (html == null)
                {
                    if (crawledLinks.Count == onlyOneElement)
                    {
                        break;
                    }

                    continue;
                }

                var links = _parser.GetLinksFromHtml(html, item.Url);

                item.IsCrawled = true;

                foreach (var link in links)
                {
                    if (!crawledLinks.Any(a => (a.Url == link)))
                    {
                        Link newLink = new Link() { IsCrawled = false, Url = link, Timing = timer.ElapsedMilliseconds };
                        crawledLinks.Add(newLink);
                    }
                }
            }
            timer.Stop();

            return crawledLinks;
        }
    }
}
