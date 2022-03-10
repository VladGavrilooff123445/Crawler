using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace Crawler
{
    public class WebService
    {
        private HttpClient _client;

        public WebService()
        {
            _client = new HttpClient();
        }


        public async Task<string> GetHtmlAsString(string url)
        {
            try
            {
                var response = await _client.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();
                    
                return html;    
            }
            catch
            {
                return null;
            }
        }

        public async Task<XmlDocument> GetXMLAsXmlDoc(string url)
        {
            try
            {
                string sitemapUrl = url + "sitemap.xml";
                var response = await _client.GetAsync(sitemapUrl);

                var xml = await response.Content.ReadAsStringAsync();

                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(xml);

                return xmlDocument;
            }
            catch 
            {
                return null;
            }
        }
    }
}