using Crawler.Data;
using System.Collections.Generic;

namespace Crawler.WebApplication.Models
{
    public class LinkResult
    {
        public string Url { get; set; }
        public ICollection<Link> Links { get; set; }
        public ICollection<string> OnlyInWebsite { get; set; }
        public ICollection<string> OnlyInSitemap { get; set; }
    }
}
