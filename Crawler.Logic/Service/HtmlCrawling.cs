﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crawler.Logic.Model;

namespace Crawler.Logic.Service
{
    public class HtmlCrawling
    {
        private readonly TimeResponse _timeResponse;
        private readonly TimeEvaluate _timeEvaluate;
        private readonly WebService _web;
        private readonly HtmlParser _parser;

        public HtmlCrawling(HtmlParser parser, WebService web, TimeEvaluate timeEvaluate, TimeResponse timeResponse)
        {
            _timeResponse = timeResponse;
            _timeEvaluate = timeEvaluate;
            _parser = parser;
            _web = web;
        }

        public virtual async Task<List<Link>> CrawlingByHtml(string url)
        {
            List<Link> crawledLinks = new List<Link>();
            Link startLink = new Link() { Url = url };
            crawledLinks.Add(startLink);

            crawledLinks = await CrawlingLogic(crawledLinks);
            

            return crawledLinks;
        }

 
        private async Task<List<Link>> CrawlingLogic(List<Link> crawledLinks)
        {
            _timeResponse.Start();

            var onlyOneElement = 1;

            while (crawledLinks.Any(a => a.IsCrawled == false))
            {
                var item = crawledLinks.First(a => a.IsCrawled == false);
                var html = await _web.GetHtmlAsString(item.Url);
                var time = await _timeEvaluate.GetResponseTime(item.Url);

                if (html == null)
                {
                    if (crawledLinks.Count == onlyOneElement)
                    {
                        break;
                    }

                    continue;
                }
                else
                {
                    var links = _parser.GetLinksFromHtml(html, item.Url);

                    item.IsCrawled = true;

                    foreach (var link in links)
                    {
                        if (!crawledLinks.Any(a => (a.Url == link)))
                        {
                            Link newLink = new Link() { IsCrawled = false, Url = link, Time = time, InWebSite = true, InSitemap = false };
                            crawledLinks.Add(newLink);
                        }
                    }
                } 
            }

            _timeResponse.Stop();

            return crawledLinks;
        }
    }
}
