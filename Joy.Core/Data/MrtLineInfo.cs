using System.Collections.Generic;

namespace Joy.Core.Data
{
    public class MrtLineInfo
    {
        public string Name { get; set; }
        public IEnumerable<MrtStationInfo> Stations { get; set; }
    }
}
