using Crawler.Data;
using System;
using System.Collections.Generic;

namespace Crawler.WebApplication.Models
{
    public class TestResult
    {
        public ICollection<Test> Tests { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages  
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}
