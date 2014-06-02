using CallFire_csharp_sdk.API.Soap;
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
            Client = new SoapContactClient(MockClient.User(), MockClient.Password());

            ContactId = 160672080001;
            QueryContact = new CfQueryContacts();
            GetContactHistory = new CfGetContactHistory(1000, 0, ContactId);
            object[] ids = { ContactId };
            CreateContactList = new CfCreateContactList(null, "ContactListTest", false, new CfContactSource(ids));
        }
    }
}
