using NUnit.Framework;
using Moq;

namespace Crawler.LogicTests
{
    public class LogicTest
    {

        [Test]
        public void StartCrawling_ShouldReturnListOfLinks()
        {
            var mock = new Mock<CrawlerLogic>();

            var links = mock.Setup(a => a.StartCrawling("https://www.ukad-group.com/"));

            
        }
    }
}