
namespace Application.CrawlerLogic
{
    public class XmlCrawling
    {
        private readonly WebService _web;
        private readonly XmlParser _parser;

        public XmlCrawling(XmlParser parser, WebService web)
        {
            _parser = parser;
            _web = web;
        }

        public virtual async Task<List<Link>> SiteMapCrawling(string url)
        {   
            var xml = await _web.GetXMLAsXmlDoc(url);
            var links = await _parser.GetLinksFromXml(xml);

            return links;
        }
    }
}
