using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Newtonsoft.Json;
using ScrapySharp.Extensions;
namespace Joy.Core
{
    public static class MrtManager
    {
        public static string GetStationList()
        {
            HtmlNode.ElementsFlags.Remove("option");
            var webClient = new HtmlWeb();
            var doc = webClient.Load("http://www.trtc.com.tw/");
            doc.OptionWriteEmptyNodes = true;
            var lines = doc.DocumentNode.CssSelect("#sstation > optgroup");

            return JsonConvert.SerializeObject(lines.Select(line => new Line
            {
                Name = line.Attributes["label"].Value,
                Stations = line.ChildNodes.Select(station => new Station
                {
                    ID = Convert.ToInt32(station.Attributes["value"].Value),
                    Name = station.InnerHtml
                })
            }).SelectMany(x => x.Stations)
            .OrderBy(x => x.ID), Formatting.Indented);
        }

        public static IEnumerable<Line> GetAllStations()
        {
            HtmlNode.ElementsFlags.Remove("option");
            var webClient = new HtmlWeb();
            var doc = webClient.Load("http://www.trtc.com.tw/");
            doc.OptionWriteEmptyNodes = true;
            var lines = doc.DocumentNode.CssSelect("#sstation > optgroup");

            return lines.Select(line => new Line
            {
                Name = line.Attributes["label"].Value,
                Stations = line.ChildNodes.Select(station => new Station
                {
                    ID = Convert.ToInt32(station.Attributes["value"].Value),
                    Name = station.InnerHtml
                })
            });
        }
    }

    public class Line
    {
        public string Name { get; set; }
        public IEnumerable<Station> Stations { get; set; }
    }

    public class Station
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
