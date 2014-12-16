using System;
using System.Collections.Generic;
using System.Linq;
using Joy.Core.Data;
using Joy.Core.DataAccess;
using Newtonsoft.Json;


namespace Joy.Core
{
    public static class MrtHelper
    {
        public static IEnumerable<MrtLineInfo> GetAllStations()
        {
            var mrtManager = new MrtManagerProxy();
            return mrtManager.GetAllStations();
        }

        public static string TestCustomSearch()
        {
            var googleSearch = new GoogleSearchProxy
            {
                Query = GetRandomStationName()
            };

            return JsonConvert.SerializeObject(googleSearch.Execute().First(), Formatting.Indented);
        }

        private static string GetRandomStationName()
        {
            var allStations = MrtHelper.GetAllStations();
            var random = new Random();
            var nextLine = allStations.ToArray()[random.Next(allStations.Count())];
            return nextLine.Stations.ToArray()[random.Next(nextLine.Stations.Count())].Name;
        }
    }
}
