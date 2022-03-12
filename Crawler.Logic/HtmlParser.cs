using System;
using System.Collections.Generic;
using System.Linq;

namespace Crawler
{
    public class HtmlParser
    {
        private Validator _valid;

        public HtmlParser(Validator valid)
        {
            _valid = valid;
        }

        public virtual List<string> GetLinksFromHtml(string html, string url)
        {
            List<string> _result = new List<string>();
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

                _result.Add(link);

                var indexOfACloseTag = html.IndexOf(closeTag);
                html = html.Substring(indexOfACloseTag, html.Length - indexOfACloseTag);

            }

            var validLinks = _valid.MainValidator(_result);

            _result = getLinkWithDomen(validLinks, url);


            return _result;
        }

        private List<string> getLinkWithDomen(List<string> links, string url) 
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
