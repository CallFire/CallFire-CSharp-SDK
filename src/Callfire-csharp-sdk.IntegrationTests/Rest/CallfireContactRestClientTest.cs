using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.Rest
{
    [TestFixture]
    public class CallfireContactRestClientTest : CallfireContactClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Client = new RestContactClient(MockClient.User(), MockClient.Password());

            ContactId = 165251012001;
            ContactListId = 188505001;
            QueryContact = new CfQueryContacts(1000, 0, null, null, null);
            GetContactHistory = new CfGetContactHistory(1000, 0, ContactId);
            var contact1 = new CfContact(null, "Contact1_Name", "Contact1_LastName", null, "14252163710", null, null, null, null, null);
            var contact2 = new CfContact(null, "Contact2_Name", "Contact2_LastName", null, "14252163710", null, null, null, null, null);
            CfContact[] contacts = { contact1, contact2 };
            CreateContactList = new CfCreateContactList(null, "NewContactListTest", false, new CfContactSource(contacts));

            object[] contacts2 = { ContactId };
            CreateContactList2 = new CfCreateContactList(null, "NewContactListTest", false, new CfContactSource(contacts2));

            var contactNumbers = new CfContactSourceNumbers("14252163710", new[] { "homePhone" });
            CfContactSourceNumbers[] contacts3 = { contactNumbers };
            CreateContactList3 = new CfCreateContactList(null, "NewContactListTest3", false, new CfContactSource(contacts3));

            QueryContactLists = new CfQuery();

            const long contactId = 165332795001;
            const long contactListId = 188518001;
            object[] contact = { contactId };
            AddContactsToList = new CfContactListRequest(contactListId, false, new CfContactSource(contact));

            RemoveContactsFromList = new CfRemoveContactsFromList(contactListId, contactId);

            ContactLastName = "ContactLastNameRest";
            ContactFirstName = "ContactFirstNameRest";
        }
    }
}
