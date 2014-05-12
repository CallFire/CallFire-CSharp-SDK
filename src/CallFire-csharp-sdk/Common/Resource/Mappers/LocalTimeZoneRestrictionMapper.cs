using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    public class LocalTimeZoneRestrictionMapper
    {
        internal static CfLocalTimeZoneRestriction FromSoapLocalTimeZoneRestriction(LocalTimeZoneRestriction source)
        {
            return source == null ? null : new CfLocalTimeZoneRestriction(source.BeginTime, source.EndTime);
        }

        internal static LocalTimeZoneRestriction ToSoapLocalTimeZoneRestriction(CfLocalTimeZoneRestriction source)
        {
            return source == null ? null : new LocalTimeZoneRestriction(source.BeginTime, source.EndTime);
        }
    }
}
