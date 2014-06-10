using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfRegionQuery : CfQuery
    {
        public CfRegionQuery()
        {
        }

        public CfRegionQuery(long maxResults, long firstResult, CfRegion region)
            : base(maxResults, firstResult)
        {
            Region = region;
        }

        /// <summary>
        /// Region of number represented by city, state, prefix, etc...
        /// </summary>
        public CfRegion Region { get; set; }
    }
}
