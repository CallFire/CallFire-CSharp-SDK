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

            ContactId = 160672080001;
            QueryContact = new CfQueryContacts(1000, 0, null, null, null);
            GetContactHistory = new CfGetContactHistory(1000, 0, ContactId);
            //var contact1 = new CfContact(null, "Contact1_Name", "Contact1_LastName", null, "14252163710", null, null, null, null, null);
            //var contact2 = new CfContact(null, "Contact2_Name", "Contact2_LastName", null, "14252163710", null, null, null, null, null);
            object[] contacts = { ContactId, ContactId };
            CreateContactList = new CfCreateContactList(null, "NewContactListTest", false, new CfContactSource(contacts));
        }
    }
}
