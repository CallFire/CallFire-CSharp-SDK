using System.Linq;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.Resource.Mappers;

namespace CallFire_csharp_sdk.Common.Result.Mappers
{
    internal static class ContactListQueryResultMapper
    {
        internal static CfContactListQueryResult FromContactListQueryResult(ContactListQueryResult source)
        {
            if (source == null)
            {
                return null;
            }
            var contactList = source.ContactList == null ? null : source.ContactList.Select(ContactListMapper.FromContactList).ToArray();
            return new CfContactListQueryResult(source.TotalResults, contactList);
        }

        internal static ContactListQueryResult ToContactListQueryResult(CfContactListQueryResult source)
        {
            if (source == null)
            {
                return null;
            }
            var contactList = source.ContactList == null ? null : source.ContactList.Select(ContactListMapper.ToContactList).ToArray();
            return new ContactListQueryResult(source.TotalResults, contactList);
        }
    }
}
