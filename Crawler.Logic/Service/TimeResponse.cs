using System.Diagnostics;

namespace Crawler.Logic.Service
{
    public class TimeResponse
    {
        private readonly Stopwatch _timer;

        public TimeResponse(Stopwatch timer)
        {
            _timer = timer;
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public float SetTime()
        {
            return _timer.ElapsedMilliseconds;
        }
    }
}
