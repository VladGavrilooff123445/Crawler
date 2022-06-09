using Crawler.Logic.Model;
using Crawler.Logic.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crawler.BusinessLogic.Service
{
    public class DataWorker
    {
        private TimeEvaluate _timer; 

        public DataWorker()
        {
            _timer = new TimeEvaluate();
        }

        public async Task<IEnumerable<Link>> GetAllLinksForDb(IEnumerable<Link> htmlLinks, IEnumerable<Link> xmlLinks)
        {
            var result = new List<Link>();

            result.AddRange(xmlLinks);

            var HtmlLinks = htmlLinks.Select(a => a.Url).ToList();
            var exHtmlLink = result.Select(a => a.Url).ToList();

            var uniqHtmlLinks = HtmlLinks.Except(exHtmlLink).ToList();

            foreach (var link in uniqHtmlLinks)
            {
                var time = await _timer.GetResponseTime(link);
                var url = new Link { Url = link, InSitemap = false, InWebSite = true, IsCrawled = true, Time = time };
                result.Add(url);
            }

            return result;
        }

        public void GetUniqueLinks(IEnumerable<Link> htmlLinks, IEnumerable<Link> XmlLinks)
        {
            var linksHtml = htmlLinks.Select(a => a.Url).ToList();
            var linksXml = XmlLinks.Select(a => a.Url).ToList();

            foreach (var link in XmlLinks)
            {
                if (linksHtml.Contains(link.Url))
                {
                    link.IsCrawled = true;
                    link.InWebSite = true;
                }
            }

            foreach (var link in htmlLinks)
            {
                if (linksXml.Contains(link.Url))
                {
                    link.IsCrawled = true;
                    link.InSitemap = true;
                }
            }

        }
    }
}

