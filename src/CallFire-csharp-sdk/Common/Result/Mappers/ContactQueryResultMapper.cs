using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class ContactQueryResultMapper
    {
        internal static CfContactQueryResult FromContactQueryResult(ContactQueryResult source)
        {
            return source == null ? null : new CfContactQueryResult(
                source.TotalResults,
                source.Contact == null ? null : source.Contact.Select(ContactMapper.FromContact).ToArray());
        }

        internal static ContactQueryResult ToContactQueryResult(CfContactQueryResult source)
        {
            return source == null ? null : new ContactQueryResult(
                source.TotalResults,
                source.Contact == null ? null : source.Contact.Select(ContactMapper.ToContact).ToArray());
        }
    }
}
