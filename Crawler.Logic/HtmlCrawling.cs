using System.Collections.Generic;
using System.Linq;

namespace Crawler
{
    public class HtmlCrawling
    {
        private WebService _web;
        private HtmlParser _parser;
        public HtmlCrawling(HtmlParser parser, WebService web)
        {
            _parser = parser;
            _web = web;
        }

        public List<string> CrawlingByHtml(string url)
        {
            List<Link> crawledLinks = new List<Link>();

            Link startLink = new Link() { IsCrawled = false, Url = url };

            crawledLinks.Add(startLink);

            while (crawledLinks.Any(a => a.IsCrawled == false))
            {
                var item = crawledLinks.First(a => a.IsCrawled == false);

                var html = _web.GetHtmlAsString(item.Url);

                html.Wait();

                if (html == null)
                {
                    continue;
                }

                var Links = _parser.GetLinksFromHtml(html.Result, item.Url);

                item.IsCrawled = true;

                foreach (var link in Links)
                {
                    if (!crawledLinks.Any(a => (a.Url == link)))
                    {
                        Link newLink = new Link() { IsCrawled = false, Url = link };
                        crawledLinks.Add(newLink);
                    }
                }
            }

            var result = crawledLinks
                .Select(a => a.Url)
                .ToList();

            return result;
        }
    }
}
