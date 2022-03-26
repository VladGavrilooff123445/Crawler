using Crawler.Logic.Service;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml;

namespace Crawler.LogicTests
{
    public class XmlParserTests
    { 
        private readonly XmlDocument _xmlDoc;
        private readonly XmlParser _parser;

        public XmlParserTests()
        {
            _xmlDoc = new XmlDocument();
            _parser = new XmlParser();      
        }

        [Test]
        public void GetLinksFromXml_ShouldReturnLinks()
        {
            var expectedResult = new List<string>();
            expectedResult.Add("https://www.test.com/");
            var xml = "<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" xmlns:xhtml=\"http://www.w3.org/1999/xhtml\"><url><loc>https://www.test.com/</loc><lastmod>2021-07-01T14:38:48+02:00</lastmod></url></urlset>";
            _xmlDoc.LoadXml(xml);

            var result = _parser.GetLinksFromXml(_xmlDoc);
            Assert.AreEqual(expectedResult, result);
        }
    }
}
