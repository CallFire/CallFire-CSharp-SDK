
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfContactBatchQueryResult : CfQueryResult
    {
        /// <summary>
        /// List of ContactBatches
        /// </summary>
        public CfContactBatch[] ContactBatch { get; set; }

        public CfContactBatchQueryResult(long totalResults, CfContactBatch[] contactBatch)
            : base(totalResults)
        {
            ContactBatch = contactBatch;
        }
    }
}
