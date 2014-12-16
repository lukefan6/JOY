using System.Collections.Generic;
using Joy.Core.Data;

namespace Joy.Core.DataAccess.Base
{
    public interface IMrtManager
    {
        IEnumerable<MrtLineInfo> GetAllStations();
    }
}
