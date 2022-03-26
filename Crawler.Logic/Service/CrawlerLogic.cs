using Crawler.Logic.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crawler.Logic.Service
{
    public class CrawlerLogic 
    {
        private readonly HtmlCrawling _htmlCrawling;
        private readonly XmlCrawling _xmlCrawling;

        public CrawlerLogic(HtmlCrawling htmlCrawling, XmlCrawling xmlCrawling)
        {
            _htmlCrawling = htmlCrawling;
            _xmlCrawling = xmlCrawling;
        }

        public virtual async Task<List<Link>> StartCrawlingByHtml(string url)
        {
            var resultHtml = await _htmlCrawling.CrawlingByHtml(url);

            return resultHtml;
        }

        public List<string> GetAllLinksFromSite(List<Link> htmlLinks, List<string> xmlLinks)
        {
            var result = new List<string>();
            result.AddRange(xmlLinks);

            foreach (var link in htmlLinks)
            {
                if (!result.Any(a => a.Contains(link.Url)))
                {
                    result.Add(link.Url + " - " + link.Time);
                }
            }

            return result;
        }

        public List<string> GetUniqueLinksFromHtml(List<Link> htmlLinks, List<string> xmlLinks)
        {
            var htmlUrls = htmlLinks
                .Select(a => a.Url)
                .ToList();
            var xmlUrls = xmlLinks
                .Select(a => a.Split(' '))
                .Select(a => a[0])
                .ToList();
            var result = htmlUrls
                .Except(xmlUrls)
                .ToList();

            return result;
        }

        public List<string> GetUniqueLinksFromXml(List<Link> htmlLinks, List<string> xmlLinks)
        {
            var htmlUrls = htmlLinks
                .Select(a => a.Url)
                .ToList();
            var xmlUrls = xmlLinks
                .Select(a => a.Split(' '))
                .Select(a => a[0])
                .ToList();
            var result = xmlUrls
                .Except(htmlUrls)
                .ToList();

            return result;
        }

        public virtual async Task<List<string>> StartCrawlingByXml(string url, List<Link> htmlLinks)
        {
            var resultXml = await _xmlCrawling.SiteMapCrawling(url);

            return resultXml;
        }
    }
}
