using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource
{
    public class CfSearchAvailableNumbers
    {
        public CfSearchAvailableNumbers(CfRegion region, bool tollFree, int count)
        {
            Region = region;
            TollFree = tollFree;
            Count = count;
        }

        public CfRegion Region { get; set; }

        public bool TollFree { get; set; }

        public int Count { get; set; }
    }
}
