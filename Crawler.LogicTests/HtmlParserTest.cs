using NUnit.Framework;
using Moq;
using System.Collections.Generic;

namespace Crawler.LogicTests
{
    public class HtmlParserTest
    {
        private readonly string _url;
        private readonly string _html;
        private readonly List<string> _expectedLinksHtml;
       

        public HtmlParserTest()
        {
            _url = "http://example.com/";
            _html = "<a href=\"/home\"><a hreh=\"/back\">";
            _expectedLinksHtml = new List<string>();
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

        
    }
}