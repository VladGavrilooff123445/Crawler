using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml;

namespace Crawler.Logic.Service
{
    public class XmlParser
    {
        private readonly WebService _web;

        public XmlParser(WebService web)
        {
            _web = web;
        }

        public virtual async Task<List<string>> GetLinksFromXml (XmlDocument xmlDoc)
        {
            List<string> result = new List<string>();
            XmlNodeList xmlSitemapList = xmlDoc.GetElementsByTagName("loc");
            
            foreach (XmlNode xmlSitemapNode in xmlSitemapList)
            {
                string time = await _web.GetResponseTime(xmlSitemapNode.FirstChild.InnerText);
                result.Add(xmlSitemapNode.FirstChild.InnerText + " - " + time);
            }

            return result;
        }
    }
}
