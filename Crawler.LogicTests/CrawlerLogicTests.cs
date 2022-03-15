using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Crawler.LogicTests
{
    public class CrawlerLogicTests
    {
        [Test]
        public async Task StartCrawling_ShouldReturnAllLinks()
        {
            var webMock = new Mock<WebService>();
            var validMock = new Mock<Validator>();
            var htmlParserMock = new Mock<HtmlParser>(validMock.Object);
            var xmlParserMock = new Mock<XmlParser>();
            var htmlCrawlingMock = new Mock<HtmlCrawling>(htmlParserMock.Object, webMock.Object);
            var xmlCrawlingMock = new Mock<XmlCrawling>(xmlParserMock.Object, webMock.Object);

            var expectedHtmlList = new List<string>();
            expectedHtmlList.Add("/home1");
            expectedHtmlList.Add("/back1");

            var expectedXmlList = new List<string>();
            expectedXmlList.Add("/home2");
            expectedXmlList.Add("/back2");

             

            htmlCrawlingMock.Setup(_ => _.CrawlingByHtml(It.IsAny<string>())).ReturnsAsync(expectedHtmlList);
            xmlCrawlingMock.Setup(_ => _.SiteMapCrawling(It.IsAny<string>())).ReturnsAsync(expectedXmlList);

            var crawler = new CrawlerLogic(htmlCrawlingMock.Object, xmlCrawlingMock.Object);

            var result = await crawler.StartCrawling("http://example.com/");

            Assert.AreEqual(result.Count, 4);

        }
    }
}
