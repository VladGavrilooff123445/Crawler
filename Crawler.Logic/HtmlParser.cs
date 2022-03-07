using System;
using System.Collections.Generic;
using System.Linq;

namespace Crawler
{
    public class HtmlParser
    {
        private List<string> _result;
        private Validator _valid;

        public HtmlParser(string domen)
        {
            _result = new List<string>();
            _valid = new Validator();
        }

        public string[] GetLinksFromHtml(string html, string url)
        {
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
                var link = "";

                for (int i = href.Length; i <= html.Length; i++)
                {
                    if (html[i] == endOfLink)
                    {
                        link += html[i];
                        break;
                    }
                    else
                    {
                        link += html[i];
                    }
                }

                _result.Add(link);

                var indexOfACloseTag = html.IndexOf(closeTag);
                html = html.Substring(indexOfACloseTag, html.Length - indexOfACloseTag);

            }

            Uri baseUri = new Uri(url);

            var validLinks = _valid.MainValidator(_result);

            validLinks = validLinks
                .Where(a => !a.StartsWith("http"))
                .ToList();

            List<string> returnedLinks = new List<string>();

            foreach (var link in validLinks.ToList())
            {
                Uri uri = new Uri(link, UriKind.Relative);

                if (uri.IsAbsoluteUri)
                {
                    continue;
                }

                if (Uri.TryCreate(baseUri, link, out Uri result))
                {
                    var str = result.AbsoluteUri.Substring(0, result.AbsoluteUri.Length - 3);
                    returnedLinks.Add(str);
                }
            }


            return returnedLinks.ToArray();
        }
    }
}
