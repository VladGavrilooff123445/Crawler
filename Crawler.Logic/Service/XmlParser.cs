using System.Collections.Generic;
using System.Xml;
using System.Diagnostics;

namespace Crawler.Logic
{
    public class XmlParser
    {
        public virtual List<string> GetLinksFromXml (XmlDocument xmlDoc)
        {
            Stopwatch timer = new Stopwatch();
            List<string> result = new List<string>();
            XmlNodeList xmlSitemapList = xmlDoc.GetElementsByTagName("loc");

            timer.Start();

            foreach (XmlNode xmlSitemapNode in xmlSitemapList)
            {
                result.Add(xmlSitemapNode.FirstChild.InnerText + " - " + $"{timer.ElapsedMilliseconds}");
            }

            timer.Stop();

            return result;
        }
    }
}
