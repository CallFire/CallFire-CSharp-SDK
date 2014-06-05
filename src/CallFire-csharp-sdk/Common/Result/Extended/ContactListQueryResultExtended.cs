// ReSharper disable once CheckNamespace - This an extension from API.Soap
namespace CallFire_csharp_sdk.API.Soap
{
    public partial class ContactListQueryResult
    {
        public ContactListQueryResult()
        {
        }

        public ContactListQueryResult(long totalResults, ContactList[] contactList)
        {
            TotalResults = totalResults;
            ContactList = contactList;
        }
    }
}
