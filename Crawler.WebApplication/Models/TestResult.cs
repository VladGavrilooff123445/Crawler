using Crawler.Data;
using System.Collections.Generic;

namespace Crawler.WebApplication.Models
{
    public class TestResult : PageInfo
    {
        public IEnumerable<Test> Tests { get; set; }   
    }
}
