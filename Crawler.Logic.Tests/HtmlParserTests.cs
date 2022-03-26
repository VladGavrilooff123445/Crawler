using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using Crawler.Logic.Service;

namespace Crawler.LogicTests
{
    public class HtmlParserTests
    {
        private readonly Mock<Validator> valid;

        public HtmlParserTests()
        {
           valid = new Mock<Validator>();
        }

        [Test]
        public void GetLinksFromHtml_ShouldReturnListOfLinksWithDomen()
        {
            var url = "http://example.com/";
            var html = "<a href=\"/home\"><a href=\"/back\">";

            var validLinksHtml = new List<string>();
            validLinksHtml.Add("/home");
            validLinksHtml.Add("/back");

            var expectedLinks = new List<string>();
            expectedLinks.Add("http://example.com/home");
            expectedLinks.Add("http://example.com/back");

            valid.Setup(_ => _.MainValidator(It.IsAny<List<string>>())).Returns(validLinksHtml);
            var htmlParser = new HtmlParser(valid.Object);

            var result = htmlParser.GetLinksFromHtml(html, url);
        

            Assert.AreEqual(expectedLinks, result);
        }

    }
}