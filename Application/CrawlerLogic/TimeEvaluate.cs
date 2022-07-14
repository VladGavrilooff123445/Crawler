using System.Diagnostics;
using System.Net;

namespace Application.CrawlerLogic
{
    public class TimeEvaluate
    {
        private readonly HttpClient _client;
        private readonly Stopwatch _time;

        public TimeEvaluate()
        {
            _client = new HttpClient();
            _time = Stopwatch.StartNew();
        }

        public async Task<string> GetResponseTime(string url)
        {
            var response = await _client.GetAsync(url);

            _time.Start();

            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                var time = _time.ElapsedMilliseconds.ToString();

                _time.Stop();
                
                return time;
            }

            return null;
        }
    }
}
