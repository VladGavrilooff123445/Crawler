using Crawler.Logic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Logic.Service
{
    public class XmlCrawling
    {
        private readonly WebService _web;
        private readonly XmlParser _parser;
        private readonly TimeResponse _timeResponse;

        public XmlCrawling(XmlParser parser, WebService web, TimeResponse timeResponse)
        {
            _timeResponse = timeResponse;
            _parser = parser;
            _web = web;
        }

        public virtual async Task<List<Link>> SiteMapCrawling(string url)
        {
            _timeResponse.Start();
            
            var xml = await _web.GetXMLAsXmlDoc(url);
            var links = await _parser.GetLinksFromXml(xml);

            _timeResponse.Stop();

            return links;
        }
    }
}
