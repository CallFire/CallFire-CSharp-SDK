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
    }
}
