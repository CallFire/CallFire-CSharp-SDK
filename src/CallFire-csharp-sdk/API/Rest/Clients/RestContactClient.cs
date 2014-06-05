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

            var contact = resourceList.Resource == null ? null
               : resourceList.Resource.Select(r => ContactMapper.FromContact((Contact)r)).ToArray();
            return new CfContactQueryResult(resourceList.TotalResults, contact);
        }

        public void UpdateContacts(CfContact[] updateContacts)
        {
            var arrayUpdateContacts = updateContacts == null ? null : updateContacts.Select(ContactMapper.ToContact).ToArray();
            BaseRequest<string>(HttpMethod.Put, arrayUpdateContacts, new CallfireRestRoute<Contact>());
        }

        public void RemoveContacts(CfRemoveContacts removeContacts)
        {
            var contacts = removeContacts.ContactId == null ? null
                            : removeContacts.ContactId.ToList().ConvertAll(i => i.ToString(CultureInfo.InvariantCulture)).ToArray();
            BaseRequest<string>(HttpMethod.Delete, new RemoveContacts(contacts == null ? string.Empty : string.Join(" ", contacts)),
                            new CallfireRestRoute<Contact>());
        }

        public CfContact GetContact(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Contact>(id));
            return ContactMapper.FromContact(resource.Resources as Contact);
        }

        public CfAction[] GetContactHistory(CfGetContactHistory getContactHistory)
        {
            if (getContactHistory == null)
            {
                return null;
            }
            var resource = BaseRequest<Resource>(HttpMethod.Get, new GetContactHistory(getContactHistory),
                new CallfireRestRoute<Contact>(getContactHistory.ContactId, null, ContactRestRouteObjects.History));
            var contactHistory = resource.Resources as ContactHistory;
            return contactHistory == null || contactHistory.ContactHistory1  == null ? null 
                : contactHistory.ContactHistory1.Select(ActionMapper.FromAction).ToArray();
        }

        public long CreateContactList(CfCreateContactList createContactList)
        {
            var resource = BaseRequest<ResourceReference>(HttpMethod.Post, new CreateContactList(createContactList),
                new CallfireRestRoute<Contact>(null, ContactRestRouteObjects.List, null));
            return resource.Id;
        }

        public CfContactListQueryResult QueryContactLists(CfQuery queryContactLists)
        {
            var resourceList = BaseRequest<ResourceList>(HttpMethod.Get, new Query(queryContactLists),
                new CallfireRestRoute<Contact>(null, ContactRestRouteObjects.List, null));
            
            var contactList = resourceList.Resource == null ? null
               : resourceList.Resource.Select(r => ContactListMapper.FromContactList((ContactList)r)).ToArray();
            return new CfContactListQueryResult(resourceList.TotalResults, contactList);
        }

        public void DeleteContactList(long id)
        {
            BaseRequest<string>(HttpMethod.Delete, null, new CallfireRestRoute<Contact>(id, ContactRestRouteObjects.List, null));
        }

        public void AddContactsToList(CfContactListRequest addContactsToList)
        {
            if (addContactsToList == null)
            {
                return;
            }
            BaseRequest<string>(HttpMethod.Post, new ContactListRequest(addContactsToList),
                        new CallfireRestRoute<Contact>(addContactsToList.ContactListId, ContactRestRouteObjects.List, ContactRestRouteObjects.Add));
        }

        public CfContactList GetContactList(long id)
        {
            var resource = BaseRequest<Resource>(HttpMethod.Get, null, new CallfireRestRoute<Contact>(id, ContactRestRouteObjects.List, null));
            return ContactListMapper.FromContactList(resource.Resources as ContactList);
        }

        public void RemoveContactsFromList(CfRemoveContactsFromList removeContactsFromList)
        {
            if (removeContactsFromList == null)
            {
                return;
            }
            BaseRequest<string>(HttpMethod.Post, new RemoveContactsFromList(removeContactsFromList),
                new CallfireRestRoute<Contact>(removeContactsFromList.ContactListId, ContactRestRouteObjects.List, ContactRestRouteObjects.Remove));
        }
    }
}
