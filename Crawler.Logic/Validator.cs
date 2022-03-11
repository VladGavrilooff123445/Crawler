using System.Collections.Generic;
using System.Linq;

namespace Crawler
{
    public class Validator
    {
        private readonly char[] _notValidSymbols = { '#', '@', '?' };

        public List<string> MainValidator(List<string> links)
        {
            List<string> mainResult = new List<string>();

            mainResult = links
                .Distinct()
                .Where(a => !_notValidSymbols.Any(a.Contains))
                .ToList();
            

            return mainResult;
        }    
    }
}