using System.Collections.Generic;
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
    }
}
