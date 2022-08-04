using Application.Services;
using Application.Interfaces;
using Application.Model;

namespace Application.BussinessLogic
{
    public class LinkCrawler
    {
        private readonly HtmlCrawling _htmlCrawling;
        private readonly XmlCrawling _xmlCrawling;
        private readonly ILinkRepository _repository;
        public LinkCrawler(HtmlCrawling htmlCrawling, XmlCrawling xmlCrawling, ILinkRepository repository)
        {  
            _htmlCrawling = htmlCrawling;
            _xmlCrawling = xmlCrawling;
            _repository = repository;
        }

        public async Task<IEnumerable<Link>> CrawlingUrl(string url)
        {
            DateTime date = DateTime.Now;
            var linksHtml = await _htmlCrawling.CrawlingByHtml(url);
            var linksXml = await _xmlCrawling.SiteMapCrawling(url);

            var allLinks = SetUpDataforDB(linksHtml, linksXml);

            await SaveResultToDataBase(allLinks, url, date);

            return allLinks;
        }

        private ICollection<Link> SetUpDataforDB(ICollection<Link> htmlLinks, ICollection<Link> xmlLinks)
        {
            var result = htmlLinks.Intersect(xmlLinks).ToList();

            foreach (var link in result)
            {
                link.InSitemap = true;
                link.InWebSite = true;
            }

            var uniqHtmlLinks = htmlLinks.Except(xmlLinks).ToList();
            var uniqXmlLinks = xmlLinks.Except(htmlLinks).ToList();


            result.AddRange(uniqXmlLinks);
            result.AddRange(uniqHtmlLinks);

            return result;
        }

        private async Task SaveResultToDataBase(IEnumerable<Link> links, string url, DateTime date)
        {
            await _repository.SetDataToDb(links, date, url);
        }
    }
}
