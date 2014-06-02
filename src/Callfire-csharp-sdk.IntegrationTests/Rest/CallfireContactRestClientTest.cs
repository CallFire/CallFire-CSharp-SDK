using CallFire_csharp_sdk.API.Rest.Clients;
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
            object[] ids = { ContactId };
            CreateContactList = new CfCreateContactList(null, "ContactListTest", false, new CfContactSource(ids));
        }
    }
}
