namespace Crawler
{
    public class CrawlerLogic
    {
        public void Parse(string url)
        {
            WebService web = new WebService();

            var html = web.GetHtmlAsString(url);

            HtmlParser parser = new HtmlParser();

            var hrefs = parser.GetHrefsFromHtml(html);

            var links = parser.GetLinksFromHrefs(hrefs, url);

            var result = parser.ValidationOfLink(links, url);

            foreach (var link in result)
            {
                Parse(link);
            }
        } 
    }
}
