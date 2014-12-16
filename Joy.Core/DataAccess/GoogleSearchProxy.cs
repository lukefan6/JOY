using System.Collections.Generic;
using Joy.Core.DataAccess.Base;

namespace Joy.Core.DataAccess
{
    public class GoogleSearchProxy : IGoogleSearch
    {
        private const string cacheKeyPrefix = "GoogleSearchResult";
        private IGoogleSearch _googleSearch;

        public GoogleSearchProxy()
        {
            _googleSearch = new GoogleSearchImpl();
        }

        #region IGoogleSearch 成員

        public string Query
        {
            get { return _googleSearch.Query; }
            set { _googleSearch.Query = value; }
        }

        public IEnumerable<Data.GoogleSearchResult> Execute()
        {
            var proxy = new Proxy<IEnumerable<Data.GoogleSearchResult>>(
                string.Format("{0}_{1}", cacheKeyPrefix, _googleSearch.Query),
                () => _googleSearch.Execute());

            return proxy.Get();
        }

        #endregion
    }
}
