using System.Collections.Generic;
using Joy.Core.Data;
using Joy.Core.DataAccess.Base;

namespace Joy.Core.DataAccess
{
    public class MrtManagerProxy : IMrtManager
    {
        private const string cacheKey = "MrtLineInfo";
        private IMrtManager _mrtManager;
        private Proxy<IEnumerable<MrtLineInfo>> _proxy;

        public MrtManagerProxy()
        {
            _mrtManager = new MrtManagerImpl();
            _proxy = new Proxy<IEnumerable<MrtLineInfo>>(cacheKey, () => _mrtManager.GetAllStations());
        }

        #region IMrtManager 成員

        public IEnumerable<MrtLineInfo> GetAllStations()
        {
            return _proxy.Get();
        }

        #endregion
    }
}
