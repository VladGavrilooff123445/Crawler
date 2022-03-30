using Crawler.Logic.Model;
using System.Collections.Generic;
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

        public virtual async Task<List<Link>> GetLinksFromXml (XmlDocument xmlDoc)
        {
            List<Link> result = new List<Link>();
            XmlNodeList xmlSitemapList = xmlDoc.GetElementsByTagName("loc");
            
            foreach (XmlNode xmlSitemapNode in xmlSitemapList)
            {
                string timer = await _time.GetResponseTime(xmlSitemapNode.FirstChild.InnerText);
                Link link = new Link() { Url = xmlSitemapNode.FirstChild.InnerText, Time = timer };

                result.Add(link);
            }

            return result;
        }
    }
}
