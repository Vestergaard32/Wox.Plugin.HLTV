using System.Collections.Generic;

namespace HltvScraperTest
{
    public class CSEvent
    {
        public List<string> GameTimes { get; set; }

        public CSEvent()
        {
            GameTimes = new List<string>();
        }
    }
}