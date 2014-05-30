using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class ContactQueryResultMapper
    {
        internal static CfContactQueryResult FromContactQueryResult(ContactQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var contact = source.Contact == null ? null : source.Contact.Select(ContactMapper.FromContact).ToArray();
            return new CfContactQueryResult(source.TotalResults, contact);
        }

        internal static ContactQueryResult ToContactQueryResult(CfContactQueryResult source)
        {
            if (source == null)
            {
                return null;
            }

            var contact = source.Contact == null ? null : source.Contact.Select(ContactMapper.ToContact).ToArray();
            return new ContactQueryResult(source.TotalResults, contact);
        }
    }
}
