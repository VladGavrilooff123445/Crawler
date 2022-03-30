using Crawler.Logic.Model;
using System.Collections.Generic;
using System.Linq;

namespace Crawler.ConsoleApplication
{
    public class ConsoleResult
    {
        public List<string> GetUniqueLinks(List<Link> unexcept, List<Link> except)
        {
            var unExceptUrls = unexcept
                .Select(a => a.Url)
                .ToList();
            var exceptUrls = except
                .Select(a => a.Url)
                .ToList();
            var result = unExceptUrls
                .Except(exceptUrls)
                .ToList();

            return result;
        }

        public List<string> GetAllLinksFromSite(List<Link> htmlLinks, List<Link> xmlLinks)
        {
            var result = new List<string>();
            var htmlUrls = htmlLinks
                .Select(a => a.Url)
                .ToList();

            result = htmlLinks
                .Select(a => a.Url + " - " + a.Time)
                .ToList();
            
            foreach (var link in xmlLinks)
            {
                if(!htmlUrls.Contains(link.Url))
                {
                    result.Add(link.Url + " - " + link.Time);
                }
            }


            return result;
        }
    }
}
