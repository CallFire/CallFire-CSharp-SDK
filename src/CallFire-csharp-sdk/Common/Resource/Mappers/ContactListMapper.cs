using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;

namespace CallFire_csharp_sdk.Common.Resource.Mappers
{
    internal static class ContactListMapper
    {
        internal static CfContactList FromContactList(ContactList source)
        {
            return source == null ? null : new CfContactList(source);
        }

        internal static ContactList ToContactList(CfContactList source)
        {
            return source == null ? null : new ContactList(source);
        }
    }
}
