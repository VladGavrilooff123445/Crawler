using Application.Model;

namespace Application.Interfaces
{
    public interface ILinkRepository
    {
        Task SetDataToDb(IEnumerable<Link> links, DateTime date, string url);
        Task<int> GetCountTestResult();

        Task<IReadOnlyList<Domain.Test>> GetTestResult(int amountOfPage, int pageSize);

        Task<IReadOnlyList<Domain.Link>> GetTestUrlsById(int id);

    }
}
