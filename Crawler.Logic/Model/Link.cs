namespace Crawler.Logic.Model
{
    public class Link
    {
        public string Url { get; set; }

        public bool IsCrawled { get; set; }

        public string Time { get; set; }

        public bool InWebSite { get; set; }

        public bool InSitemap { get; set; }
    }
}