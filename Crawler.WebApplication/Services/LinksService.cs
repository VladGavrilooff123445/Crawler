using Application.Interfaces;
using Crawler.WebApplication.Models;
using System.Threading.Tasks;

namespace Crawler.WebApplication.Services
{
    public class LinksService
    {
        private readonly ILinkRepository _repository;

        public LinksService(ILinkRepository repository)
        {
            _repository = repository;
        }

        public async Task<LinkResult> GetListOfLinks(int id)
        {
            var linksResult = new LinkResult() { Links = await _repository.GetTestUrlsById(id) };

            return linksResult;
        }
    }
}
