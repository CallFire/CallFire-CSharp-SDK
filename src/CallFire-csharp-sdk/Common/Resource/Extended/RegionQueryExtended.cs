using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;

// ReSharper disable once CheckNamespace - This is an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class RegionQuery
    {
        public RegionQuery()
        {
        }

        public RegionQuery(CfRegionQuery source)
        {
            MaxResults = source.MaxResults;
            FirstResult = source.FirstResult;
            Region = RegionMapper.ToRegion(source.Region);
        }
    }
}
