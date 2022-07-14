using System;
using System.Collections.Generic;

namespace Infrastucture.CrawlerData
{
    public class Test
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public DateTime? Date { get; set; }
        public List<Link> Links { get; set; }
    }
}
