using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Xml;

namespace Crawler.LogicTests
{
    public class XmlParserTest
    { 
        private readonly List<string> _expectedLinksXml;
        private readonly XmlDocument _xmlDoc;

        public XmlParserTest()
        {
            _xmlDoc = new XmlDocument();
            _expectedLinksXml = new List<string>();
            _expectedLinksXml.Add("https://www.test.com/");
        }

        [Test]
        public void GetLinksFromXml_ShouldReturnLinks()
        {
            var xmlParser = new Mock<XmlParser>();
            var xml = "<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" xmlns:xhtml=\"http://www.w3.org/1999/xhtml\"><url><loc> https://www.test.com/</loc><lastmod>2021-07-01T14:38:48+02:00</lastmod></url></urlset>";
            _xmlDoc.LoadXml(xml);
            xmlParser.Setup(_ => _.GetLinksFromXml(_xmlDoc)).Returns(_expectedLinksXml);

            var links = xmlParser.Object.GetLinksFromXml(_xmlDoc);

            xmlParser.Verify(_ => _.GetLinksFromXml(_xmlDoc), Times.Once);

            Assert.AreEqual(_expectedLinksXml.Count, links.Count);

        }
    }
}
