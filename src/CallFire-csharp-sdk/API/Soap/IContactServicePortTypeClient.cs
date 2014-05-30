namespace CallFire_csharp_sdk.API.Soap
{
    public interface IContactServicePortTypeClient : IServicePortClient
    {
        ContactQueryResult QueryContacts(QueryContacts queryContacts1);
        void UpdateContacts(Contact[] updateContacts1);
        void RemoveContacts(RemoveContacts removeContacts1);
        Contact GetContact(IdRequest getContact1);
        Action[] GetContactHistory(GetContactHistory getContactHistory1);
    }
}
