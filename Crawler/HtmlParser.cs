using System;
using System.Collections.Generic;
using System.Linq;

namespace Crawler
{
    public class HtmlParser
    {
        private int _linkPosition = 1;
       
        public string[] GetHrefsFromHtml(string html)
        {
            string[] elements = html.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var hrefs = elements.Select(a => a).Where(a => a.StartsWith("href=\"")).ToList();

            return hrefs.ToArray();
        }

        public List<string> GetLinksFromHrefs(string[] hrefs, string URL)
        {
            var url = URL.Substring(0, URL.Length - 1);

            List<string> links = new List<string>();

            foreach (var href in hrefs)
            {
                var link = href.Split(new char[] { '\"', '\"' }, StringSplitOptions.RemoveEmptyEntries);

                if (link[_linkPosition].StartsWith("/"))
                {
                    links.Add(link[_linkPosition].Insert(0, url));
                }
                else
                {
                    links.Add(link[_linkPosition]);
                }
            }

            return links;
        }

        public string[] ValidationOfLink(List<string> linkList, string url)
        {
            var URL = url.Substring(0, url.Length - 1);

            var result = linkList
                .Select(a => a)
                .Where(a => a.StartsWith(URL))
                .ToList();

            return result.ToArray();
        }
    }
}
