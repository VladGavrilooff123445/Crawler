using System.Collections.Generic;
using System.Linq;

namespace Crawler
{
    public class Validator
    {
        private List<string> _result;
        private char[] _notValidSymbols = { '#', '@', '?' };

        public Validator()
        {
            _result = new List<string>();
        }

        public List<string> MainValidator(List<string> links)
        {
            List<string> mainResult = new List<string>();
            mainResult = DeleteDuplicateLinks(links);

            foreach (var symbol in _notValidSymbols)
            {
                mainResult = mainResult
                    .Select(a => a)
                    .Where(a => !a.Contains(symbol))
                    .ToList();
            }

            return mainResult;

        }

        private List<string> DeleteDuplicateLinks(List<string> links)
        {
            _result = links.Select(a => a)
                .Distinct()
                .ToList();

            return _result;
        }
    }
}