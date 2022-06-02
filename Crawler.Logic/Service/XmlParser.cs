using Crawler.Logic.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Crawler.Logic.Service
{
    public class XmlParser
    {
        private readonly TimeEvaluate _time;

        public XmlParser(TimeEvaluate time)
        {
            _time = time;
        }

        public virtual async Task<List<Link>> GetLinksFromXml(XmlDocument xmlDoc, List<Link> existLinks)
        {
            List<Link> result = new List<Link>();
            XmlNodeList xmlSitemapList = xmlDoc.GetElementsByTagName("loc");

            var links = existLinks.Select(a => a.Url).ToList();

            foreach (XmlNode xmlSitemapNode in xmlSitemapList)
            {
                string timer = await _time.GetResponseTime(xmlSitemapNode.FirstChild.InnerText);

                if (links.Contains(xmlSitemapNode.FirstChild.InnerText))
                {
                    Link link = new Link() { IsCrawled = true, Url = xmlSitemapNode.FirstChild.InnerText, Time = timer, InSitemap = true, InWebSite = true };
                    result.Add(link);
                }
                else
                {
                    Link link = new Link() { IsCrawled = false, Url = xmlSitemapNode.FirstChild.InnerText, Time = timer, InSitemap = true, InWebSite = false };
                    result.Add(link);
                }
            }

            return result;
        }
    }
}
