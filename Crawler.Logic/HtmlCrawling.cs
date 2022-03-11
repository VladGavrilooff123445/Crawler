using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<List<string>> CrawlingByHtml(string url)
        {
            List<Link> crawledLinks = new List<Link>();

            Link startLink = new Link() { Url = url };

            crawledLinks.Add(startLink);

            while (crawledLinks.Any(a => a.IsCrawled == false))
            {
                var item = crawledLinks.First(a => a.IsCrawled == false);

                var html = await _web.GetHtmlAsString(item.Url);

                if (html == null)
                {
                    continue;
                }

                var Links = _parser.GetLinksFromHtml(html, item.Url);

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
