using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<List<string>> SiteMapCrawling(string url)
        {
            var xml = await _web.GetXMLAsXmlDoc(url);

            var links = _parser.GetLinksFromXml(xml);

            return links;
        }
    }
}
