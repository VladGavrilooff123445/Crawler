using System.Net;
using System.Xml;

namespace Crawler
{
    public class WebService
    {
        public string GetHtmlAsString(string url)
        {
            try
            {
                WebClient client = new WebClient();
                string html = client.DownloadString(url);
                return html;
            }
            catch 
            {
                return null;
            }
        }

        public XmlDocument GetXMLAsXmlDoc(string url)
        {
            try
            {
                string sitemapUrl = url + "sitemap.xml";
                WebClient client = new WebClient();

                client.Encoding = System.Text.Encoding.UTF8;
                string xml = client.DownloadString(sitemapUrl);

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);


                return xmlDoc;
            }
            catch 
            {
                return null;
            }
        }
    }
}