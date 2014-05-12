
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfContactBatchQueryResult : CfQueryResult
    {
        public CfContactBatch[] ContactBatch { get; set; }

        public CfContactBatchQueryResult(long totalResults, CfContactBatch[] contactBatch)
        {
            TotalResults = totalResults;
            ContactBatch = contactBatch;
        }
    }
}
