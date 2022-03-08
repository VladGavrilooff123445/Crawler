using System.Net;

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
            catch (WebException e)
            {
                return null;
            }
        }
    }
}