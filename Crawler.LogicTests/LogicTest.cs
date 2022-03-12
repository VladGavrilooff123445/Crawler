using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Xml;

namespace Crawler.LogicTests
{
    public class LogicTest
    {
        private readonly string _url;
        private readonly string _html;
        private readonly List<string> _expectedLinksHtml;
        private readonly List<string> _expectedLinksXml;
        private readonly XmlDocument _xmlDoc;

        public LogicTest()
        {
            _url = "http://example.com/";
            _html = "<a href=\"/home\"><a hreh=\"/back\">";
            _xmlDoc = new XmlDocument();
            _expectedLinksHtml = new List<string>();
            _expectedLinksXml = new List<string>();
            _expectedLinksXml.Add("https://www.test.com/");
            _expectedLinksHtml.Add("/home");
            _expectedLinksHtml.Add("/back");
        }

        [Test]
        public void GetLinksFromHtml_ShouldReturnListOfLinks()
        {
            var validator = new Mock<Validator>();

            var parser = new Mock<HtmlParser>(validator.Object);

            parser.Setup(_ => _.GetLinksFromHtml(_html, _url)).Returns(_expectedLinksHtml);

            var links = parser.Object.GetLinksFromHtml(_html, _url);

            parser.Verify(_ => _.GetLinksFromHtml(_html, _url), Times.Once());
            Assert.AreEqual(links.Count, _expectedLinksHtml.Count);
        }

        [Test]
        public void GetLinksFromHtml_ShouldReturnLinks()
        {
            var xmlParser = new Mock<XmlParser>();
            var xml = "<urlset xmlns=\"http://www.sitemaps.org/schemas/sitemap/0.9\" xmlns:xhtml=\"http://www.w3.org/1999/xhtml\"><url><loc> https://www.test.com/</loc><lastmod>2021-07-01T14:38:48+02:00</lastmod></url></urlset>";
            _xmlDoc.LoadXml(xml);
            xmlParser.Setup(_ => _.GetLinksFromXml(_xmlDoc)).Returns(_expectedLinksXml);

            var links = xmlParser.Object.GetLinksFromXml(_xmlDoc);

            xmlParser.Verify(_ => _.GetLinksFromXml(_xmlDoc), Times.Once);

            Assert.AreEqual(_expectedLinksXml.Count, links.Count);

        }

        [Test]
        public void GetXMLAsXmlDoc_ShouldSendRequest()
        {
            var web = new Mock<WebService>();
            web.Setup(_ => _.GetXMLAsXmlDoc(_url));

            var xml = web.Object.GetXMLAsXmlDoc(_url);

            web.Verify(_ => _.GetXMLAsXmlDoc(_url), Times.Once);
        }


    }
}