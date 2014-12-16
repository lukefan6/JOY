using System.Collections.Generic;
using Joy.Core.Data;

namespace Joy.Core.DataAccess.Base
{
    interface IGoogleSearch
    {
        string Query { get; set; }
        IEnumerable<GoogleSearchResult> Execute();
    }
}
