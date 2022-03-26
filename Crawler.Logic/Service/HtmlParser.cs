using System;
using System.Collections.Generic;
using System.Linq;

namespace Crawler.Logic.Service
{
    public class HtmlParser
    {
        private readonly Validator _valid;

        public HtmlParser(Validator valid)
        {
            _valid = valid;
        }

        public virtual List<string> GetLinksFromHtml(string html, string url)
        {
            var linksFromHtml = GetLinkFromPage(html);
            var validLinks = _valid.MainValidator(linksFromHtml);
            var result = GetLinkWithDomain(validLinks, url);

            return result;
        }


        private List<string> GetLinkFromPage(string html)
        {
            List<string> links = new List<string>();
            string aOpenTag = "<a ";
            char closeTag = '>';
            var endOfLoop = -1;

            while (true)
            {
                var indexOfAOpenTag = html.IndexOf(aOpenTag);

                if (indexOfAOpenTag == endOfLoop)
                {
                    break;
                }

                html = html.Substring(indexOfAOpenTag, html.Length - indexOfAOpenTag);

                var href = "href=\"";

                var indexOfHref = html.IndexOf(href);
                html = html.Substring(indexOfHref, html.Length - indexOfHref);

                var endOfLink = '"';
                var link = string.Empty;

                for (int i = href.Length; i <= html.Length; i++)
                {
                    if (html[i] == endOfLink)
                    {
                        break;
                    }

                    link += html[i];
                }

                links.Add(link);

                var indexOfACloseTag = html.IndexOf(closeTag);
                html = html.Substring(indexOfACloseTag, html.Length - indexOfACloseTag);

            }

            return links;
        }

        private List<string> GetLinkWithDomain(List<string> links, string url) 
        {
            Uri baseUri = new Uri(url);


            List<string> returnedLinks = new List<string>();

            links = links
                .Where(a => !a.StartsWith("http"))
                .ToList();

            foreach (var link in links)
            {
                Uri uri = new Uri(link, UriKind.RelativeOrAbsolute);

                if (Uri.TryCreate(baseUri, link, out Uri result))
                {
                    var str = result.AbsoluteUri;
                    returnedLinks.Add(str);
                }
            }

            return returnedLinks;
        }
    }
}
