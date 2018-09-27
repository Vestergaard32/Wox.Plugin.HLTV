using System.Collections.Generic;

namespace Hltv
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