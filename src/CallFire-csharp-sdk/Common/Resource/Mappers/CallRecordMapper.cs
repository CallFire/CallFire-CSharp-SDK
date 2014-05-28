using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class CallRecordMapper
    {
        internal static CfCallRecord[] FromCallRecord(CallRecord[] source)
        {
            return source == null ? null : source.Select(FromCallRecord).ToArray();
        }

        internal static CallRecord[] ToCallRecord(CfCallRecord[] source)
        {
            return source == null ? null : source.Select(ToCallRecord).ToArray();
        }

        internal static CfCallRecord FromCallRecord(CallRecord source)
        {
            // TODO 
            return null;
        }

        internal static CallRecord ToCallRecord(CfCallRecord source)
        {
            // TODO
            return null;
        }
    }
}
