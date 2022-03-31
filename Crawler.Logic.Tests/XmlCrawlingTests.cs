using NUnit.Framework;
using Moq;
using System.Xml;
using System.Collections.Generic;
using System.Threading.Tasks;
using Crawler.Logic.Service;

namespace Crawler.LogicTests
{
    public class XmlCrawlingTests
    {
        private readonly Mock<XmlParser> _parser;
        private readonly Mock<WebService> _web;

        public XmlCrawlingTests()
        {
            _parser = new Mock<XmlParser>();
            _web = new Mock<WebService>();
        }

        [Test]
        public async Task SiteMapCrawling_ShouldReturnLinks()
        {
            var links = new List<string>();
            links.Add(It.IsAny<string>());
            links.Add("/home");
            links.Add("/back");
           

            
        }
    }
}