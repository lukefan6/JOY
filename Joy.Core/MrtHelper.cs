using System;
using System.Collections.Generic;
using System.Linq;
using Google.Apis.Customsearch.v1.Data;
using Joy.Core.Data;
using Joy.Core.DataAccess;


namespace Joy.Core
{
    public static class MrtHelper
    {
        public static IEnumerable<MrtLineInfo> GetAllStations()
        {
            var mrtManager = new MrtManagerProxy();
            return mrtManager.GetAllStations();
        }

        public static IEnumerable<Result> TestCustomSearch()
        {
            var googleSearch = new GoogleSearchProxy
            {
                Query = GetRandomStationName()
            };

            return googleSearch.Execute();
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
