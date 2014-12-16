using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;
using Joy.Core.Data;
using Joy.Core.DataAccess.Base;
using ScrapySharp.Extensions;

namespace Joy.Core.DataAccess
{
    public class MrtManagerImpl : IMrtManager
    {

        #region IMrtManager 成員

        public IEnumerable<MrtLineInfo> GetAllStations()
        {
            HtmlNode.ElementsFlags.Remove("option");
            var webClient = new HtmlWeb();
            var doc = webClient.Load("http://www.trtc.com.tw/");
            var lines = doc.DocumentNode.CssSelect("#sstation > optgroup");

            return lines.Select(line => new MrtLineInfo
            {
                Name = line.Attributes["label"].Value,
                Stations = line.ChildNodes.Select(station => new MrtStationInfo
                {
                    ID = Convert.ToInt32(station.Attributes["value"].Value),
                    Name = station.InnerHtml
                })
            });
        }

        #endregion
    }
}
