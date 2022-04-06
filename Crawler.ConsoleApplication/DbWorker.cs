using Crawler.Logic.Model;
using Crawler.Data;
using System.Collections.Generic;
using System;
using System.Data;

namespace Crawler.ConsoleApplication
{
    public class DbWorker
    {
        private readonly IRepository<Links> _perfomanceAllLinksData;
        private readonly IRepository<UniqueLink> _perfomanceUniqueLinksData;

        public async void SetAllLinksToDataBase(List<Link> allLinks)
        {
            var count = 1;

            foreach(var link in allLinks)
            {
                 Links linkItem = new Links() { Id = count, Url = link.Url, ResponseTime = Convert.ToInt32(link.Time) };
                 _perfomanceAllLinksData.Add(linkItem);
                 count++;
            }

            await _perfomanceUniqueLinksData.SaveChangesAsync();
        }

        public async void SetUniqueLinkToDataBase(List<string> uniqHtml, List<string> uniqXml)
        {
            var count = 1;

            foreach (var link in uniqHtml)
            {
                UniqueLink linkItem = new UniqueLink() { Id = count, Url = link, InWebsite = true, InSitemap = false };
                _perfomanceUniqueLinksData.Add(linkItem);
                count++;
            }

            foreach (var link in uniqXml)
            {
                UniqueLink linkItem = new UniqueLink() { Id = count, Url = link, InSitemap = true, InWebsite = false };
                _perfomanceUniqueLinksData.Add(linkItem);
                count++;
            }

            await _perfomanceUniqueLinksData.SaveChangesAsync();
        }
    }
}
