﻿using System;
using Crawler.Data;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Linq;

namespace Crawler.BusinessLogic.Service
{
    public class DbWorker
    {
        private readonly IRepository<Link> _performanceLinksData;
        private readonly IRepository<Test> _performanceTestData;

        public DbWorker(IRepository<Link> performanceLinksData, IRepository<Test> performanceTestData)
        {
            _performanceLinksData = performanceLinksData;
            _performanceTestData = performanceTestData;
        }

        public async Task SetDataToDb(List<Logic.Model.Link> links, DateTime date, string url)
        {
            var newTest = new Test { Url = url, Date = date };
            await _performanceTestData.AddAsync(newTest);
            await _performanceTestData.SaveChangesAsync();

            _performanceLinksData.AddRange(
                links
                .Select(p => new Link() { 
                    Url = p.Url, 
                    ResponseTime = Convert.ToInt32(p.Time), 
                    InSitemap = p.InSitemap, 
                    InWebsite = p.InWebSite, 
                    TestId = newTest.Id }));

            await _performanceLinksData.SaveChangesAsync();
        }
    }
}
