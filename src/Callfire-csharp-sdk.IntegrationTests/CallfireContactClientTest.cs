using System.Linq;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
{
    [TestFixture]
    public abstract class CallfireContactClientTest
    {
        protected IContactClient Client;

        protected CfQueryContacts QueryContact;
        protected CfGetContactHistory GetContactHistory;
        protected CfCreateContactList CreateContactList;
        protected long ContactId;

        [Test]
        public void Test_QueryContact()
        {
            var contacts = Client.QueryContacts(QueryContact);
            Assert.IsNotNull(contacts);
            Assert.IsTrue(contacts.Contact.Any(c => c.Id == ContactId));
        }

        [Test]
        public void Test_GetContact()
        {
            var contact = Client.GetContact(ContactId);
            Assert.IsNotNull(contact);
            Assert.AreEqual(contact.HomePhone, "14252163710");
        }

        [Test]
        public void Test_GetContactHistory()
        {
            var contactHistory = Client.GetContactHistory(GetContactHistory);
            Assert.IsNotNull(contactHistory);
            Assert.IsTrue(contactHistory.Any(ch => ch.Id == 210128059001));
            Assert.IsTrue(contactHistory.Any(ch => ch.BroadcastId == 1838228001));
        }

        [Test]
        public void Test_CreateContactList()
        {
            var id = Client.CreateContactList(CreateContactList);
            Assert.IsTrue(id > 0);
        }
    }
}
