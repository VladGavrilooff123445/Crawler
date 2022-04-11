using Crawler.Data;
using System.Collections.Generic;

namespace Crawler.WebApplication.Models
{
    public class LinkResult
    {
        public string Url { get; set; }
        public List<Link> Links { get; set; }
        public List<string> OnlyInWebsite { get; set; }
        public List<string> OnlyInSitemap { get; set; }
    }
}
