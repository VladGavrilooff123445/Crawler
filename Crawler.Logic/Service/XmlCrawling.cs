﻿using Crawler.Logic.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Logic.Service
{
    public class XmlCrawling
    {
        private readonly WebService _web;
        private readonly XmlParser _parser;

        public XmlCrawling(XmlParser parser, WebService web)
        {
            _parser = parser;
            _web = web;
        }

        public virtual async Task<List<Link>> SiteMapCrawling(string url, List<Link> existLinks)
        {   
            var xml = await _web.GetXMLAsXmlDoc(url);
            var links = await _parser.GetLinksFromXml(xml, existLinks);

            return links;
        }
    }
}
