using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Crawler.Logic.Service;

namespace Crawler.LogicTests
{
    public class WebServiceTests
    {
        private readonly string _url;
        private readonly List<string> _expectedLinksXml;
        private readonly Mock<WebService> _web;

        public WebServiceTests()
        {
            _web = new Mock<WebService>();
            _url = "http://example.com/";
            _expectedLinksXml = new List<string>();
            _expectedLinksXml.Add("https://www.test.com/");
        }

        [Test]
        public void GetXMLAsXmlDoc_ShouldSendRequest_ReturnXmlDoc()
        {
            _web.Setup(_ => _.GetXMLAsXmlDoc(_url));

            var xml = _web.Object.GetXMLAsXmlDoc(_url);

            _web.Verify(_ => _.GetXMLAsXmlDoc(_url), Times.Once);
        }

        [Test]
        public void GetHtmlAsString_ShouldSendRequest_ReturnHtml()
        {
            _web.Setup(_ => _.GetHtmlAsString(_url));

            var html = _web.Object.GetHtmlAsString(_url);

            _web.Verify(_ => _.GetHtmlAsString(_url), Times.Once);
        }

        [Test]
        public void GetHtmlAsstring_ShouldGetFailIfUrlNotValid_ReturnNull()
        {
            var url = "dksdjfsdjf";

            _web.Setup(_ => _.GetHtmlAsString(url));

            var html = _web.Object.GetHtmlAsString(url);
            html.Wait();
            _web.Verify(_ => _.GetHtmlAsString(url));

            Assert.IsNull(html.Result);
        }
    }
}
