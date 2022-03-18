using System.Collections.Generic;
using System.Threading.Tasks;

namespace Crawler.Logic.Controler
{
    public interface ICrawlerLogic
    {
       Task<List<string>> StartCrawlingByHtml(string url);
       Task<List<string>> StartCrawlingByXml(string url);
    }
}
