using NUnit.Framework;
using Moq;

namespace Crawler.ConsoleApplicationTests
{
    public class ConsoleApplicationTest
    {

        [Test]
        public void Main_ShouldReturnNumberOfLinks()
        {
            var service = new Mock<ConsoleService>();

            var url = service
                .Setup(_ => _.ReadLine())
                .Returns("https://www.ukad-group.com/");

            var app = new Mock<CrawlerLogic>();

            var links = app
                .Setup(_ => _.StartCrawling(url.ToString()));

            // Act
            var l = app.Object.StartCrawling("https://www.ukad-group.com/");

            service
                .Verify(_ => _.WriteLine(l.Count.ToString()), Times.Once);
            Assert.Equals("152", l.Count.ToString());
        }
    }
}