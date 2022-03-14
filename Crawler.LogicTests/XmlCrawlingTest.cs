using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Threading.Tasks;

namespace Crawler.LogicTests
{
    public class XmlCrawlingTest
    {
        private readonly string _url;

        public XmlCrawlingTest()
        {
            _url = "https://www.ukad-group.com/";
        }

        [Test]
        public void SiteMapCrawling_ShouldReturnLinks()
        {
            var parser = new Mock<XmlParser>();
            var web = new Mock<WebService>();
            var crawler = new Mock<XmlCrawling>(parser.Object, web.Object);

            crawler.Setup(_ => _.SiteMapCrawling(_url));
            var links = crawler.Object.SiteMapCrawling(_url);

            crawler.Verify(_ => _.SiteMapCrawling(_url), Times.Once);

        }
    }
}