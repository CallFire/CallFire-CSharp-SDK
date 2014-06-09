using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API
{
    public interface IContactClient : IClient
    {
        /// <summary>
        /// Lists existing contacts
        /// </summary>
        /// <param name="queryContacts"></param>
        /// <returns>List of Contacts</returns>
        CfContactQueryResult QueryContacts(CfQueryContacts queryContacts);

        /// <summary>
        /// Updates existing contacts
        /// </summary>
        /// <param name="updateContacts"></param>
        void UpdateContacts(CfContact[] updateContacts);

        /// <summary>
        /// Removes contacts
        /// </summary>
        /// <param name="removeContacts"></param>
        void RemoveContacts(CfRemoveContacts removeContacts);

        /// <summary>
        /// Gets the contact by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <returns>Contact requested</returns>
        CfContact GetContact(long id);

        /// <summary>
        /// Gets a contact's history by contact ID
        /// </summary>
        /// <param name="getContactHistory"></param>
        /// <returns>List Calls or Texts associated with Contact</returns>
        CfAction[] GetContactHistory(CfGetContactHistory getContactHistory);

        /// <summary>
        /// Create new contact list and add to account
        /// </summary>
        /// <param name="createContactList"></param>
        /// <returns>Unique ID of resource</returns>
        long CreateContactList(CfCreateContactList createContactList);

        /// <summary>
        /// Lists existing contact lists
        /// </summary>
        /// <param name="queryContactLists"></param>
        /// <returns>List of ContactLists</returns>
        CfContactListQueryResult QueryContactLists(CfQuery queryContactLists);

        /// <summary>
        /// Deletes a contact list by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        void DeleteContactList(long id);
        
        /// <summary>
        /// Adds contacts to an existing list
        /// </summary>
        /// <param name="addContactsToList"></param>
        void AddContactsToList(CfContactListRequest addContactsToList);
        
        /// <summary>
        /// Gets the contact list by ID
        /// </summary>
        /// <param name="id">Unique ID of resource</param>
        /// <returns>Contact list requested</returns>
        CfContactList GetContactList(long id);
        
        /// <summary>
        /// Removes contacts from a list without deleting the contacts
        /// </summary>
        /// <param name="removeContactsFromList"></param>
        void RemoveContactsFromList(CfRemoveContactsFromList removeContactsFromList);
    }
}
