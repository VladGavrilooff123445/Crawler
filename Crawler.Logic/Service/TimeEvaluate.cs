using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Crawler.Logic.Service
{
    public class TimeEvaluate
    {
        private readonly TimeResponse _timeResponse;
        private readonly HttpClient _client;

        public TimeEvaluate(TimeResponse timeResponse)
        {
            _client = new HttpClient();
            _timeResponse = timeResponse;
        }

        public async Task<string> GetResponseTime(string url)
        {
            var response = await _client.GetAsync(url);

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                var time = _timeResponse.SetTime().ToString();
                
                return time;
            }

            return null;
        }
    }
}
