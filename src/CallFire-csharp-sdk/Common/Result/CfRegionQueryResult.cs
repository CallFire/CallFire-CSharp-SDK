using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Result
{
    public class CfRegionQueryResult : CfQueryResult
    {
        public CfRegionQueryResult(long totalResult, CfRegion[] region)
        {
            TotalResults = totalResult;
            Region = region;
        }

        public CfRegion[] Region { get; set; }
    }
}
