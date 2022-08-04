﻿using System.Net;
using System.Diagnostics;
using System.Xml;

namespace Application.Services
{
    public class WebService
    {
        private readonly HttpClient _client;  

        public WebService()
        {
            _client = new HttpClient();
        }

        public virtual async Task<string> GetHtmlAsString(string url)
        {
            var response = await _client.GetAsync(url);

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                var html = await response.Content.ReadAsStringAsync();

                return html;
            }

            return null;    
        }

        public virtual async Task<XmlDocument> GetXMLAsXmlDoc(string url)
        {
            string sitemapUrl = url + "sitemap.xml";
            var response = await _client.GetAsync(sitemapUrl);
            var xml = await response.Content.ReadAsStringAsync();
            var xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xml);

            return xmlDocument;
        }
    }
}