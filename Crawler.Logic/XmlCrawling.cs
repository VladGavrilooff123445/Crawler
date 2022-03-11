using System.Collections.Generic;

namespace Crawler
{
    public class XmlCrawling
    {
        private WebService _web;
        private XmlParser _parser;
        public XmlCrawling(XmlParser parser, WebService web)
        {
            _parser = parser;
            _web = web;
        }
        public List<string> SiteMapCrawling(string url)
        {
            var xml = _web.GetXMLAsXmlDoc(url);

            xml.Wait();

            var links = _parser.GetLinksFromXml(xml.Result);

            return links;
        }
    }
}
