using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class RegionQueryResultMapper
    {
        internal static CfRegionQueryResult FromRegionQueryResult(RegionQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var region = source.Region == null ? null
                            : source.Region.Select(RegionMapper.FromRegion).ToArray();
            return new CfRegionQueryResult(source.TotalResults, region);
        }

        internal static RegionQueryResult ToRegionQueryResult(CfRegionQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var region = source.Region == null ? null
                            : source.Region.Select(RegionMapper.ToRegion).ToArray();
            return new RegionQueryResult(source.TotalResults, region);
        }
    }
}
