using System.Linq;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
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
        protected CfCreateContactList CreateContactList2;
        protected CfCreateContactList CreateContactList3;
        protected CfQuery QueryContactLists;
        protected CfContactListRequest AddContactsToList;
        protected CfRemoveContactsFromList RemoveContactsFromList;
        protected long ContactId;
        protected long ContactListId;
        
        [Test]
        public void Test_QueryContact()
        {
            var contacts = Client.QueryContacts(QueryContact);
            Assert.IsNotNull(contacts);
            Assert.IsNotNull(contacts.Contact);
            Assert.IsTrue(contacts.Contact.Any(c => c.Id == ContactId));
        }

        //QueryContacts
        [Test]
        public void Test_QueryContactsNotExistContactListId()
        {
            //ContactListId= no exist
        }
        [Test]
        public void Test_QueryContactsAllResults()
        {

            //go to Try it out!

        }

        [Test]
        public void Test_QueryContactsComplete()
        {

            //fields complete
            //MaxResults 200
            //FirstResult 90
        }

        //UpdateContacts
        [Test]
        public void Test_UpdateContactsMandatory()
        {

            //Mandatory fields complete
            
        }
        [Test]
        public void Test_UpdateContactsComplete()
        {

            // fields complete

        }
        [Test]
        public void Test_UpdateContactsInvalidID()
        {

            // ID invalid
            //resto de los campos existentes
        }
        //RemoveContacts
        [Test]
        public void Test_RemoveContactsInvalidId()
        {

            // invalid id
        }
        [Test]
        public void Test_RemoveContactsIdNull()
        {
            //
        }
        [Test]
        public void Test_RemoveContactsComplete()
        {
            //valid id
        }

        //GetContact
        [Test]
        public void Test_GetContactValidId()
        {
            //ID Valido
        }

        [Test]
        public void Test_GetContactInValidId()
        {
            //ID InValido
        }
        [Test]
        public void Test_GetContactIDnull()
        {
            //ID null
        }
        //GetContactHistory
        [Test]
        public void Test_GetContactHistoryMandatory()
        {
            //mandatory field
        }
        [Test]
        public void Test_GetContactHistoryComnplete()
        {
            //complete all field
        }
        [Test]
        public void Test_GetContactHistoryIdNull()
        {
            //ContactId= null
        }

        //CreateContactList
        [Test]
        public void Test_CreateContactListMandatory()
        {
            //MandatoryFieds completes
        }
        [Test]
        public void Test_CreateContactListComplete()
        {
            //All fields complete
            //Validate= true
            //csv file correct
        }
        [Test]
        public void Test_CreateContactListWrongFormatFile()
        {
            //
        }
        //QueryContactLists
        [Test]
        public void Test_QueryContactListsAllResults()
        {

            //go to Try it out!

        }

        [Test]
        public void Test_QueryContactListsComplete()
        {

            //MaxResults 2
            //FirstResult 600
        }

        //DeleteContactList
        [Test]
        public void Test_DeleteContactListInvalidId()
        {

            // invalid id
        }
        [Test]
        public void Test_DeleteContactListIdNull()
        {
            //
        }
        [Test]
        public void Test_DeleteContactListComplete()
        {
            //valid id
        }

        //AddContactsToList
        [Test]
        public void Test_AddContactsToListMandatory()
        {
            //
        }
        [Test]
        public void Test_AddContactsToListComplete()
        {
            //all fields complete
            //Validate = true
        }
        //GetContactList
        [Test]
        public void Test_GetContactListValidId()
        {
            //ID Valido
        }

        [Test]
        public void Test_GetContactListInValidId()
        {
            //ID InValido
        }
        [Test]
        public void Test_GetContactListIDnull()
        {
            //ID null
        }
        //RemoveContactsFromList
        [Test]
        public void Test_RemoveContactsFromListInvalidId()
        {

            // invalid id
        }
        [Test]
        public void Test_RemoveContactsFromListIdNull()
        {
            //
        }
        [Test]
        public void Test_RemoveContactsFromListComplete()
        {
            //valid id
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
        public void Test_CreateContactList_Contact()
        {
            var id = Client.CreateContactList(CreateContactList);
            Assert.IsTrue(id > 0);
        }

        [Test]
        public void Test_CreateContactList_ContactId()
        {
            var id = Client.CreateContactList(CreateContactList2);
            Assert.IsTrue(id > 0);
        }

        [Test]
        [Ignore]
        public void Test_CreateContactList_ContactSourceNumbers()
        {
            var id = Client.CreateContactList(CreateContactList3);
            Assert.IsTrue(id > 0);
        }
        
        [Test]
        public void Test_QueryContactList()
        {
            var contactListQueryResult = Client.QueryContactLists(QueryContactLists);
            Assert.IsNotNull(contactListQueryResult);
            Assert.IsNotNull(contactListQueryResult.ContactList);
            Assert.IsTrue(contactListQueryResult.ContactList.Any(c => c.Name.Equals("NewContactListTest")));
        }

        [Test]
        public void Test_DeleteContactList()
        {
            var id = Client.CreateContactList(CreateContactList2);
            Client.DeleteContactList(id);
        }

        [Test]
        public void Test_GetContactList()
        {
            var contactList = Client.GetContactList(188601001);
            Assert.IsNotNull(contactList);
            Assert.IsTrue(contactList.Status.Equals(CfContactListStatus.Active) && contactList.Size.Equals("2"));
        }

        [Test]
        public void Test_AddContactToList()
        {
            Client.AddContactsToList(AddContactsToList);
            Client.RemoveContactsFromList(RemoveContactsFromList);
        }
    }
}
