using Application.Model;
using System.Xml;

namespace Application.Services
{
    public class XmlParser
    {
        private readonly TimeEvaluate _time;

        public XmlParser(TimeEvaluate time)
        {
            _time = time;
        }

        public virtual async Task<List<Link>> GetLinksFromXml(XmlDocument xmlDoc)
        {
            List<Link> result = new List<Link>();
            XmlNodeList xmlSitemapList = xmlDoc.GetElementsByTagName("loc");

            foreach (XmlNode xmlSitemapNode in xmlSitemapList)
            {
                string timer = await _time.GetResponseTime(xmlSitemapNode.FirstChild.InnerText);
                Link link = new Link() { IsCrawled = false, Url = xmlSitemapNode.FirstChild.InnerText, Time = timer, InSitemap = true};
                result.Add(link);
            }

            return result;
        }
    }
}
