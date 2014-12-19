using System.Collections.Generic;
using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using Joy.Core.DataAccess.Base;

namespace Joy.Core.DataAccess
{
    public class GoogleSearchImpl : IGoogleSearch
    {
        private string _query;

        private string ApiKey
        {
            get
            {
                return AppSettingConfig.GetAppSettingOrDefault(
                    "GoogleSearchApiKey",
                    "AIzaSyCVPf1NRflms2BU991OuEr_S0YVXpl7YgA");
            }
        }

        private string SearchEngineID
        {
            get
            {
                return AppSettingConfig.GetAppSettingOrDefault(
                    "SearchEngineID",
                    "010603030665905026317:kyztlnwe2tg");
            }
        }

        #region IGoogleSearch 成員

        string IGoogleSearch.Query
        {
            get { return _query; }
            set { _query = value; }
        }

        IEnumerable<Result> IGoogleSearch.Execute()
        {
            var service = new CustomsearchService(new BaseClientService.Initializer
            {
                ApiKey = ApiKey
            });

            var listRequest = service.Cse.List(_query ?? string.Empty);
            listRequest.Cx = SearchEngineID;

            return listRequest.Execute().Items;
        }

        #endregion
    }
}
