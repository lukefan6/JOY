using System.Collections.Generic;
using Google.Apis.Customsearch.v1.Data;

namespace Joy.Core.DataAccess.Base
{
    interface IGoogleSearch
    {
        string Query { get; set; }
        IEnumerable<Result> Execute();
    }
}
