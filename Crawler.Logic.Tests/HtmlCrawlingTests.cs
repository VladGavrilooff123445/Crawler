using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crawler.Logic.Service;

namespace Crawler.LogicTests
{
    public class HtmlCrawlingTests
    {
        private readonly Mock<Validator> _valid;
        private readonly Mock<WebService> _web;
        private readonly Mock<HtmlParser> _parser;

        public HtmlCrawlingTests()
        {
            _valid = new Mock<Validator>();
            _web = new Mock<WebService>();
            _parser = new Mock<HtmlParser>(_valid.Object);    
        }

        [Test]
        public async Task CrawlingByHtml_ShouldReturnNotEmptyList()
        {
            var html = "<a href=\"/home\"><a hreh=\"/back\">";

            var links = new List<string>();
            links.Add(It.IsAny<string>());
            links.Add("/home");
            links.Add("/back");

            _web.Setup(_ => _.GetHtmlAsString(It.IsAny<string>())).ReturnsAsync(html);
            _parser.Setup(_ => _.GetLinksFromHtml(html, It.IsAny<string>())).Returns(links);

            HtmlCrawling crawler = new HtmlCrawling(_parser.Object, _web.Object);
            var result = await crawler.CrawlingByHtml(It.IsAny<string>());

            Assert.AreEqual(links, result);
        }

    }
}
