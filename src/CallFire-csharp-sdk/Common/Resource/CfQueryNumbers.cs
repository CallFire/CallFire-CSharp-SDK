using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfQueryNumbers : CfRegionQuery
    {
        public CfQueryNumbers(long maxResults, long firstResult, CfRegion region, string labelName)
            : base(maxResults, firstResult, region)
        {
            LabelName = labelName;
        }

        public string LabelName { get; set; }
    }
}
