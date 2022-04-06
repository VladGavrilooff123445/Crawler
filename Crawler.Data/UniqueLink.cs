namespace Crawler.Data
{
    public class UniqueLink
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool? InSitemap { get; set; }
        public bool? InWebsite { get; set; }
    }
}
