using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap


namespace CallFire_csharp_sdk.API.Soap
{
    public partial class SearchAvailableNumbers
    {
        public SearchAvailableNumbers(CfSearchAvailableNumbers source)
        {
            Region = RegionMapper.ToRegion(source.Region);
            TollFree = source.TollFree;
            Count = source.Count;
        }
    }
}
