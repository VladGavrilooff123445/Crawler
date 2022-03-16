namespace Crawler.ConsoleApplication
{
    class Program
    {
       static void Main(string[] args)
       {
            ConsoleApp app = new ConsoleApp();

            app.Run().Wait();  
       }
    }
}
