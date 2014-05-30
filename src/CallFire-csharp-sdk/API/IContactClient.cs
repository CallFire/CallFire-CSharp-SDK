using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface IContactClient : IClient
    {
        CfContactQueryResult QueryContacts(CfQueryContacts queryContacts);

        void UpdateContacts(CfContact[] updateContacts);

        void RemoveContacts(CfRemoveContacts removeContacts);

        CfContact GetContact(long id);

        CfAction[] GetContactHistory(CfGetContactHistory getContactHistory);

        long CreateContactList(CfCreateContactList createContactList);

        CfContactListQueryResult QueryContactLists(CfQuery queryContactLists);

        void DeleteContactList(long id);
        
        void AddContactsToList(CfContactListRequest addContactsToList);
        
        CfContactList GetContactList(long id);
        
        void RemoveContactsFromList(CfRemoveContactsFromList removeContactsFromList);
    }
}
