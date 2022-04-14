using Crawler.Data;
using System;
using System.Collections.Generic;

namespace Crawler.WebApplication.Models
{
    public class TestResult : PageInfo
    {
        public ICollection<Test> Tests { get; set; }   
    }
}
