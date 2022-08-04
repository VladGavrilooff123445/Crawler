using Domain;
using System.Collections.Generic;

namespace Crawler.WebApplication.Models
{
    public class TestResult : PageInfo
    {
        public IReadOnlyList<Test> Tests { get; set; }   
    }
}
