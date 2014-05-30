using System.Globalization;
using System.Linq;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;

namespace CallFire_csharp_sdk.API.Soap
{
    public class SoapContactClient : BaseSoapClient, IContactClient
    {
        internal IContactServicePortTypeClient ContactService;

        public SoapContactClient(string username, string password)
        {
            ContactService = new ContactServicePortTypeClient(GetCustomBinding(), GetEndpointAddress<Contact>())
            {
                ClientCredentials = { UserName = { UserName = username, Password = password } }
            };
        }

        internal SoapContactClient(IContactServicePortTypeClient client)
        {
            ContactService = client;
        }

        public CfContactQueryResult QueryContacts(CfQueryContacts queryContacts)
        {
            return ContactQueryResultMapper.FromContactQueryResult(ContactService.QueryContacts(new QueryContacts(queryContacts)));
        }

        public void UpdateContacts(CfContact[] updateContacts)
        {
            ContactService.UpdateContacts(updateContacts.Select(ContactMapper.ToContact).ToArray());
        }

        public void RemoveContacts(CfRemoveContacts removeContacts)
        {
            var contacts = removeContacts.ContactId.ToList().ConvertAll(i => i.ToString(CultureInfo.InvariantCulture)).ToArray();
            ContactService.RemoveContacts(new RemoveContacts(string.Join(" ", contacts)));
        }

        public CfContact GetContact(long id)
        {
            return ContactMapper.FromContact(ContactService.GetContact(new IdRequest(id)));
        }

        public CfAction[] GetContactHistory(CfGetContactHistory getContactHistory)
        {
            var action = ContactService.GetContactHistory(new GetContactHistory(getContactHistory));
            return action.Select(ActionMapper.FromAction).ToArray();
        }
    }
}
