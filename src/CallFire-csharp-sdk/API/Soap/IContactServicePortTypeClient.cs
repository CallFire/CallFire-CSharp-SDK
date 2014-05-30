namespace CallFire_csharp_sdk.API.Soap
{
    public interface IContactServicePortTypeClient : IServicePortClient
    {
        ContactQueryResult QueryContacts(QueryContacts queryContacts1);
        void UpdateContacts(Contact[] updateContacts1);
        void RemoveContacts(RemoveContacts removeContacts1);
        Contact GetContact(IdRequest getContact1);
        Action[] GetContactHistory(GetContactHistory getContactHistory1);
        long CreateContactList(CreateContactList createContactList1);
        ContactListQueryResult QueryContactLists(Query queryContactLists1);
        void DeleteContactList(IdRequest deleteContactList1);
        void AddContactsToList(ContactListRequest addContactsToList1);
        ContactList GetContactList(IdRequest getContactList1);
        void RemoveContactsFromList(RemoveContactsFromList removeContactsFromList1);
    }
}
