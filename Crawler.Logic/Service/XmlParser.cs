using System.Collections.Generic;
using System.Xml;

namespace Crawler
{
    public class XmlParser
    {
        public virtual List<string> GetLinksFromXml (XmlDocument xmlDoc)
        {
            List<string> result = new List<string>();
            XmlNodeList xmlSitemapList = xmlDoc.GetElementsByTagName("loc");

            foreach (XmlNode xmlSitemapNode in xmlSitemapList)
            {
                result.Add(xmlSitemapNode.FirstChild.InnerText);
            }

            return result;
        }
    }
}
