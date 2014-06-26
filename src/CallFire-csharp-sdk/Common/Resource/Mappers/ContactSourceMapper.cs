using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class ContactSourceMapper
    {
        internal static CfContactSource FromContactSource(ContactSource source)
        {
            return source == null ? null : new CfContactSource(source.Items);
        }

        internal static ContactSource ToContactSource(CfContactSource source)
        {
            return source == null ? null : new ContactSource(source.Items);
        }
    }
}
