using Crawler.Logic.Model;
using Crawler.Logic.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crawler.BusinessLogic.Service
{
    public class DataWorker
    {
        public async Task<List<Link>> GetAllLinksFromSite(List<Link> htmlLinks, List<Link> xmlLinks)
        {
            var result = new List<Link>();

            result.AddRange(xmlLinks);

            var HtmlLinks = htmlLinks.Select(a => a.Url).ToList();
            var exHtmlLink = result.Select(a => a.Url).ToList();

            var uniqHtmlLinks = HtmlLinks.Except(exHtmlLink).ToList();

            foreach(var link in uniqHtmlLinks)
            {
                var timer = new TimeEvaluate();
                var url = new Link { Url = link, InSitemap = false, InWebSite = true, IsCrawled = true, Time = await timer.GetResponseTime(link) };
                result.Add(url);
            }

            return result;
        }
    }
}

