using NUnit.Framework;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Crawler.Logic;

namespace Crawler.LogicTests
{
    public class CrawlerLogicTests
    {
        [Test]
        public async Task StartCrawlingByXml_ShouldReturnAllLinks()
        {
            var webMock = new Mock<WebService>();
            var validMock = new Mock<Validator>();
            var htmlParserMock = new Mock<HtmlParser>(validMock.Object);
            var xmlParserMock = new Mock<XmlParser>();
            var htmlCrawlingMock = new Mock<HtmlCrawling>(htmlParserMock.Object, webMock.Object);
            var xmlCrawlingMock = new Mock<XmlCrawling>(xmlParserMock.Object, webMock.Object);

            var expectedXmlList = new List<string>();
            expectedXmlList.Add("/home2");
            expectedXmlList.Add("/back2");

            xmlCrawlingMock.Setup(_ => _.SiteMapCrawling(It.IsAny<string>())).ReturnsAsync(expectedXmlList);

            var crawler = new CrawlerLogic(htmlCrawlingMock.Object, xmlCrawlingMock.Object);

            var result = await crawler.StartCrawlingByXml("http://example.com/");

            Assert.AreEqual(result.Count, 2);

        }
    }
}
