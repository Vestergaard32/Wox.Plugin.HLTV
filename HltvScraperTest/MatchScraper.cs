using System.Collections.Generic;
using System.Data;
using System.Linq;
using HtmlAgilityPack;

namespace HltvScraperTest
{
    public class MatchScraper
    {
        public List<CSEvent> CsEvents { get; set; }
        public MatchScraper()
        {
            CsEvents = new List<CSEvent>();
        }

        public void Scrape()
        {
            var web = new HtmlWeb();
            var doc = web.Load("https://www.hltv.org/matches");

            var nodes = doc.DocumentNode.SelectNodes("//table//tr");
            var table = new DataTable("MyTable");
            
            PopulateHeaders(table, nodes);
            PopulateRows(nodes, table);
            PopulateCsGoEvents(table);
        }

        private void PopulateCsGoEvents(DataTable table)
        {
            foreach (DataRow tableRow in table.Rows)
            {
                if(!string.IsNullOrEmpty(tableRow[0].ToString()))
                {
                    var csEvent = new CSEvent();
                    foreach (DataColumn tableColumn in table.Columns)
                    {
                        var row = tableRow[tableColumn.Ordinal].ToString().Replacify();
                        if (!string.IsNullOrEmpty(row))
                            csEvent.GameTimes.Add(tableColumn.ColumnName + " : " + row);
                    }
                
                    if(csEvent.GameTimes.Count !=0)
                        CsEvents.Add(csEvent);        
                }   
            }
        }

        private void PopulateRows(HtmlNodeCollection nodes, DataTable table)
        {
            var rows = nodes.Skip(1).Select(tr => tr
                .Elements("td")
                .Where(x => x.Attributes["class"].Value.Contains("guide"))
                .Select(td => td.InnerText.Trim())
                .ToArray());
            foreach (var row in rows)
            {
                table.Rows.Add(row);
            }
        }

        private void PopulateHeaders(DataTable table, HtmlNodeCollection nodes)
        {
            var headers = nodes[0]
                .Elements("th")
                .Select(th => th.InnerText.Trim());
            
            foreach (var header in headers)
            {
                table.Columns.Add(header);
            }
        }
    }
}