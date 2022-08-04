using Domain;
using System.Collections.Generic;

namespace Crawler.WebApplication.Models
{
    public class LinkResult
    { 
        public IEnumerable<Link> Links { get; set; }
    }
}
