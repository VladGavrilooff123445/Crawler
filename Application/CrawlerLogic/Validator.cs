namespace Application.CrawlerLogic
{
    public class Validator
    {
        private readonly char[] _notValidSymbols = { '#', '@', '?' };

        public virtual List<string> MainValidator(List<string> links)
        {
            var mainResult = links
                .Distinct()
                .Where(a => !_notValidSymbols.Any(a.Contains))
                .ToList();
            
            return mainResult;
        }    
    }
}