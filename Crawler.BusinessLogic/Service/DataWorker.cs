using Crawler.Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Crawler.BusinessLogic.Service
{
    public class DataWorker
    {
        public ICollection<Link> GetAllLinksForDb(ICollection<Link> htmlLinks, ICollection<Link> xmlLinks)
        {
            var result = htmlLinks.Intersect(xmlLinks).ToList();

            foreach (var link in result)
            {
                link.InSitemap = true;
                link.InWebSite = true;
            }

            var uniqHtmlLinks = htmlLinks.Except(xmlLinks).ToList();
            var uniqXmlLinks = xmlLinks.Except(htmlLinks).ToList();


            result.AddRange(uniqXmlLinks);
            result.AddRange(uniqHtmlLinks);

            return result; 
        }
    }
}

