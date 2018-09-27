using System;

namespace HltvScraperTest
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var scraper = new MatchScraper();
            scraper.Scrape();

            scraper.CsEvents.ForEach(x => x.GameTimes.ForEach(Console.WriteLine));
        }
    }
}