using System;

namespace Crawler.Data
{
    public class Link
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? ResponseTime { get; set; }
        public bool? InSitemap { get; set; }
        public bool? InWebsite { get; set; }
    }
}
