using Crawler.Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Crawler.ConsoleApplication.Service
{
    public class ConsoleResult
    {
        public List<Link> GetUniqueLinks(List<Link> unexcept, List<Link> except)
        {
            var result = new List<Link>();
            
            var urlsExc = except
                .Select(a => a.Url)
                .ToList();
            var urlsUn = unexcept
                .Select(a => a.Url)
                .ToList();

            var resExc = urlsExc
                .Except(urlsUn)
                .ToList();

            var step = 1;

            foreach (var link in resExc)
            {
                foreach (var i in except)
                {
                    if (link == i.Url)
                    {
                        Link item = new Link() { Url = link, Time = i.Time, InSitemap = i.InSitemap, InWebSite = i.InWebSite };
                        result.Add(item);
                        break;
                    }
                }

                step++;

                if (urlsExc.Count == step)
                {
                    break;
                }
            }

            return result;
        }

        public List<Link> GetAllLinksFromSite(List<Link> htmlLinks, List<Link> xmlLinks)
        {
            var result = new List<Link>();

            var urlsHtml = htmlLinks
                .Select(a => a.Url)
                .ToList();
            var urlsXml = xmlLinks
                .Select(a => a.Url)
                .ToList();

            urlsHtml.AddRange(urlsXml);

            var resUrls = urlsHtml.Distinct().ToList();

            var step = 1;

            foreach (var link in resUrls)
            {
                foreach (var i in xmlLinks)
                {
                    if (link == i.Url)
                    {
                        Link item = new Link() { Url = link, Time = i.Time, InSitemap = i.InSitemap, InWebSite = i.InWebSite };
                        result.Add(item);
                        break;
                    }
                }

                step++;

                if (resUrls.Count == step)
                {
                    break;
                }
            }

            return result;
        }
    }
}
