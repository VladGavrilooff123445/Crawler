using System;

namespace Crawler.WebApplication.Models
{
    public abstract class PageInfo
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 5;
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
}
