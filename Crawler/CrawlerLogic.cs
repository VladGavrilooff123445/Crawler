namespace Crawler
{
    public class CrawlerLogic
    {
        public void Parse()
        {
            ConsoleService service = new ConsoleService();

            var url = service.ReadLine();

            WebService web = new WebService();

            var html = web.GetHtmlAsString(url);

            HtmlParser parser = new HtmlParser();

            var hrefs = parser.GetHrefsFromHtml(html);

            var links = parser.GetLinksFromHrefs(hrefs, url);

            var result = parser.ValidationOfLink(links, url);

            foreach(var link in result)
            {
                service.WriteLine(link);
            }
        } 
    }
}
