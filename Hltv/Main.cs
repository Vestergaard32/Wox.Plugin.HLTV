using System.Collections.Generic;
using System.Linq;
using Wox.Plugin;

namespace Hltv
{
    public class Main : IPlugin
    {
        private MatchScraper _scraper;
        
        public List<Result> Query(Query query)
        {
            _scraper.Scrape();

            var results = new List<Result>();

            foreach (var t in _scraper.CsGoEvents)
            {
                var result = new Result
                {
                    Title = t.GameTimes[0],
                    SubTitle = t.GameTimes.Aggregate((a,b) => a + " " + b).Replace(t.GameTimes[0], ""),
                    IcoPath = "icon.png",
                    Action = e => false
                };

                results.Add(result);
            }
            
            return results;
        }

        public void Init(PluginInitContext context)
        {
            _scraper = new MatchScraper();
        }
    }
}