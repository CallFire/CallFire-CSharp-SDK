using System.Globalization;
using System.Linq;
using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using CallFire_csharp_sdk.Common.Result;

namespace CallFire_csharp_sdk.API.Rest.Clients
{
    public class RestContactClient : BaseRestClient<Contact>, IContactClient
    {
        public RestContactClient(string username, string password)
            : base(username, password)
        {
        }

        internal RestContactClient(IHttpClient xmlClient)
            : base(xmlClient)
        {
        }

        public CfContactQueryResult QueryContacts(CfQueryContacts queryContacts)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new QueryContacts(queryContacts),
                new CallfireRestRoute<Contact>());

            var contact = ResourceListOperations.CastResourceList<Contact>(resourceList).Select(ContactMapper.FromContact).ToArray();
            return new CfContactQueryResult(resourceList.TotalResults, contact);
        }

        public void UpdateContacts(CfContact[] updateContacts)
        {
            BaseRequest<string>(HttpMethod.Put, updateContacts.Select(ContactMapper.ToContact).ToArray(), new CallfireRestRoute<Contact>());
        }

        public void RemoveContacts(CfRemoveContacts removeContacts)
        {
            var contacts = removeContacts.ContactId.ToList().ConvertAll(i => i.ToString(CultureInfo.InvariantCulture)).ToArray();
            BaseRequest<string>(HttpMethod.Delete, new RemoveContacts(string.Join(" ", contacts)), new CallfireRestRoute<Contact>());
        }

        public CfContact GetContact(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Contact>(id));
            return ContactMapper.FromContact(resource.Resources as Contact);
        }

        public CfAction[] GetContactHistory(CfGetContactHistory getContactHistory)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, new GetContactHistory(getContactHistory), new CallfireRestRoute<Contact>(null, null, RestRouteObjects.History));
            var contactHistory = resource.Resources as ContactHistory;
            return contactHistory == null ? null : contactHistory.ContactHistory1.Select(ActionMapper.FromAction).ToArray();
        }
    }
}
