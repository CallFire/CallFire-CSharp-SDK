using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfCreateNumberOrderBulkLocal
    {
        public CfCreateNumberOrderBulkLocal(int count, CfRegion region)
        {
            Count = count;
            Region = region;
        }

        public int Count { get; set; }

        /// <summary>
        /// Region of number represented by city, state, prefix, etc...
        /// </summary>
        public CfRegion Region { get; set; }    
    }
}
