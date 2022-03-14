using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace Crawler.LogicTests
{
    public class WebServiceTest
    {
        private readonly string _url;
        private readonly List<string> _expectedLinksXml;
        private readonly Mock<WebService> _web;

        public WebServiceTest()
        {
            _web = new Mock<WebService>();
            _url = "http://example.com/";
            _expectedLinksXml = new List<string>();
            _expectedLinksXml.Add("https://www.test.com/");
        }

        [Test]
        public void GetXMLAsXmlDoc_ShouldSendRequest()
        {
            _web.Setup(_ => _.GetXMLAsXmlDoc(_url));

            var xml = _web.Object.GetXMLAsXmlDoc(_url);

            _web.Verify(_ => _.GetXMLAsXmlDoc(_url), Times.Once);
        }

        [Test]
        public void GetHtmlAsString_ShouldSendRequest()
        {
            _web.Setup(_ => _.GetHtmlAsString(_url));

            var html = _web.Object.GetHtmlAsString(_url);

            _web.Verify(_ => _.GetHtmlAsString(_url), Times.Once);
        }
    }
}
