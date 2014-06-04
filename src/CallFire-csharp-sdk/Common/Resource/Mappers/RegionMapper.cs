using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class RegionMapper
    {
        internal static CfRegion FromRegion(Region source)
        {
            if (source == null)
            {
                return null;
            }
            return new CfRegion(source.Prefix, source.City, source.State, source.Zipcode, source.Country, source.Lata,
                source.RateCenter, source.Latitude, source.Longitude, source.TimeZone);
        }

        internal static Region ToRegion(CfRegion source)
        {
            return source == null ? null : new Region(source);
        }
    }
}
