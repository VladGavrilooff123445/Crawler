using System.Collections.Generic;
using System.Linq;

namespace Crawler
{
    public class CrawlerLogic
    {
        private readonly WebService _web;
        private readonly HtmlParser _parser;
        private readonly XmlParser _xmlParser; 

        public CrawlerLogic()
        {
            _web = new WebService();
            _parser = new HtmlParser();
            _xmlParser = new XmlParser();
        }

        public virtual List<string> StartCrawling(string url)
        {
            List<Link> crawledLinks = new List<Link>();

            Link startLink = new Link() { IsCrawled = false, Url = url };

            crawledLinks.Add(startLink);  

            while (crawledLinks.Any(a => a.IsCrawled == false))
            {
                var item = crawledLinks.First(a => a.IsCrawled == false);

                var html = _web.GetHtmlAsString(item.Url);

                if(html == null)
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

        public List<string> SiteMapCrawling(string url)
        {
            var xml = _web.GetXMLAsXmlDoc(url);
            var links = _xmlParser.Parser(xml);

            return links;
        }
    }
}
