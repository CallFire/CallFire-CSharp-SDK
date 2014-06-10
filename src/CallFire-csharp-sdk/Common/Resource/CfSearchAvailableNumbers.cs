using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSearchAvailableNumbers
    {
        public CfSearchAvailableNumbers()
        {
        }

        public CfSearchAvailableNumbers(CfRegion region, bool tollFree, int count)
        {
            Region = region;
            TollFree = tollFree;
            Count = count;
        }

        /// <summary>
        /// Region of number represented by city, state, prefix, etc...
        /// </summary>
        public CfRegion Region { get; set; }

        public bool TollFree { get; set; }

        /// <summary>
        /// Keywords request by query
        /// </summary>
        public int Count { get; set; }
    }
}
