using Crawler.Logic.Model;
using Crawler.BusinessLogic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crawler.ConsoleApplication.Service
{
    public class ConsoleApp
    {
        private readonly ConsoleService _service;
        private readonly Evaluator _evaluator;
        private readonly ResultEvaluate _resultEvaluate;


        public ConsoleApp(ConsoleService service, Evaluator evaluator, ResultEvaluate resultEvaluate)
        {
            _resultEvaluate = resultEvaluate;
            _evaluator = evaluator;
            _service = service;   
        }

        public async Task Run()
        {
            var url = _service.ReadLine();
            var allLinks = await _evaluator.CrawlingUrl(url);
            
            GetAllLinks(allLinks);

            Environment.Exit(0);
        }

        private void GetAllLinks(List<Link> links)
        {
            var count = 1;  

            foreach (var link in links)
            {
                if(count == links.Count())
                {
                    _service.WriteLine($"{count}) {link.Url} - {link.Time} \n");
                    continue;
                }

                _service.WriteLine($"{count}) {link.Url} - {link.Time}");
                count++;
            }
        }
    }
}
