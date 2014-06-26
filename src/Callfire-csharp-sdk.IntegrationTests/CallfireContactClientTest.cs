using System;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Soap;
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

        protected string ContactLastName;
        protected string ContactFirstName;

        protected const string VerifyFromNumber = "+15712655344";
        protected const string VerifyShortCode = "67076";

        protected const long ExistingContactId = 169310957001;

        public void AssertClientException<TRest, TSoap>(TestDelegate test)
            where TRest : Exception
            where TSoap : Exception
        {
            if (Client.GetType() == typeof(RestContactClient))
            {
                Assert.Throws<TRest>(test);
            }
            else
            {
                Assert.Throws<TSoap>(test);
            }
        }

        /// <summary>
        /// QueryContacts
        /// </summary>
        [Test]
        public void Test_QueryContact()
        {
            var contacts = Client.QueryContacts(QueryContact);
            Assert.IsNotNull(contacts);
            Assert.IsNotNull(contacts.Contact);
            Assert.IsTrue(contacts.Contact.Any(c => c.Id == ContactId));
        }
        
        [Test]
        public void Test_QueryContactsNotExistContactListId()
        {
            var queryContacts = new CfQueryContacts
            {
                ContactListId = 192949000
            };
            var contactQueryResult = Client.QueryContacts(queryContacts);
            Assert.IsNotNull(contactQueryResult);
        }

        [Test]
        public void Test_QueryContactsAllResults()
        {
            var contactQueryResult = Client.QueryContacts(new CfQueryContacts());
            Assert.IsNotNull(contactQueryResult);
        }

        [Test]
        public void Test_QueryContactsComplete()
        {
            var queryContacts = new CfQueryContacts
            {
                ContactListId = 192950001,
                FirstResult = 90,
                MaxResults = 200,
            };
            var contactQueryResult = Client.QueryContacts(queryContacts);
            Assert.IsNotNull(contactQueryResult);
        }

        /// <summary>
        /// UpdateContacts
        /// </summary>
        [Test]
        public void Test_UpdateContactsMandatory() 
        {
            var contact = new CfContact
            {
                Id = 169299440001,
                LastName = ContactLastName,
            };
            Client.UpdateContacts(new[] { contact });
            var client = Client.GetContact(169299440001);
            Assert.AreEqual(ContactLastName, client.LastName);
        }

        [Test]
        public void Test_UpdateContactsComplete() 
        {
            var contact = new CfContact
            {
                Id = 169299440001,
                LastName = ContactLastName,
                FirstName = ContactFirstName,
                MobilePhone = VerifyFromNumber,
                WorkPhone = VerifyFromNumber,
            };
            Client.UpdateContacts(new[] { contact });
            var client = Client.GetContact(169299440001);
            Assert.AreEqual(ContactLastName, client.LastName);
            Assert.AreEqual(ContactFirstName, client.FirstName);
        }
        
        [Test]
        public void Test_UpdateContactsInvalidID()
        {
            var contact = new CfContact
            {
                Id = 169299440000,
                LastName = ContactLastName,
            };
            Client.UpdateContacts(new[] {contact});
        }

        //RemoveContacts
        [Test]
        public void Test_RemoveContactsInvalidId()
        {
            var removeContacts = new CfRemoveContacts
            {
                ContactId = new []{ (long)489684631 }
            };
            Client.RemoveContacts(removeContacts);
        }

        [Test]
        public void Test_RemoveContactsIdNull()
        {
            var removeContacts = new CfRemoveContacts
            {
                ContactId = null
            };
            Client.RemoveContacts(removeContacts);
        }

        [Test]
        public void Test_RemoveContactsComplete()
        {
            var removeContacts = new CfRemoveContacts
            {
                ContactId = new[] { 169500183001 }
            };
            Client.RemoveContacts(removeContacts);
        }

        /// <summary>
        /// GetContact
        /// </summary>
        [Test]
        public void Test_GetContactValidId()
        {
            var client = Client.GetContact(ExistingContactId);
            Assert.IsNotNull(client);
        }

        [Test]
        public void Test_GetContactInValidId()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetContact(169300956000));
        }

        /// <summary>
        /// GetContactHistory
        /// </summary>
                [Test]
        public void Test_GetContactHistoryMandatory()
        {
            var getContactHistory = new CfGetContactHistory
            {
                ContactId = 169299440001
            };
            var contactHistory = Client.GetContactHistory(getContactHistory);
            Assert.IsNotNull(contactHistory);
        }

        [Test]
        public void Test_GetContactHistoryComplete()
        {
            var getContactHistory = new CfGetContactHistory
            {
                ContactId = 169299440001,
                FirstResult = 1,
                MaxResults = 70
            };
            var contactHistory = Client.GetContactHistory(getContactHistory);
            Assert.IsNotNull(contactHistory);
        }

        [Test]
        public void Test_GetContactHistoryIdNull()
        {
            var contactHistory = Client.GetContactHistory(new CfGetContactHistory());
            Assert.IsNotNull(contactHistory);
            Assert.IsEmpty(contactHistory);
        }

        /// <summary>
        /// CreateContactList
        /// </summary>
        
        [Test]
        public void Test_CreateContactListMandatory() 
        {
            var contact1 = new CfContact
            {
                FirstName = "FirstNameContact",
                HomePhone = "14252163710"
            };

            object[] contacts = { contact1 };
            var createContactList = new CfCreateContactList
            {
                Name = "ContactList_Test_CreateContactListMandatory",
                ContactSource = new CfContactSource
                {
                    Items = contacts
                }
            };
            var id = Client.CreateContactList(createContactList);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateContactListMandatoryNumbers() 
        {
            var contactNumbers = new CfContactSourceNumbers
            {
                FieldName = "homePhone",
                Text = new[] { "14252163710" }
            };
            
            object[] contacts = { contactNumbers };
            var createContactList = new CfCreateContactList
            {
                Name = "ContactList_Test_CreateContactListMandatoryNumbers",
                ContactSource = new CfContactSource
                {
                    Items = contacts
                }
            };
            var id = Client.CreateContactList(createContactList);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateContactListMandatoryContactId()
        {
            object[] contacts = { 169299452001 };
            var createContactList = new CfCreateContactList
            {
                Name = "ContactList_Test_CreateContactListMandatoryContactId",
                ContactSource = new CfContactSource
                {
                    Items = contacts
                }
            };
            var id = Client.CreateContactList(createContactList);
            Assert.IsNotNull(id);
            var contactList = Client.GetContactList(id);
            Assert.AreNotEqual(CfContactListStatus.Errors, contactList.Status);
        }

        [Test]
        public void Test_CreateContactListComplete()
        {
            var stream = File.OpenRead("../../Files/contacts.csv");
            var fileBytes = new byte[stream.Length];

            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();

            object[] contacts = { fileBytes };
            var createContactList = new CfCreateContactList
            {
                Validate = true,
                Name = "ContactList_Test_CreateContactListMandatory",
                ContactSource = new CfContactSource
                {
                    Items = contacts
                }
            };
            var id = Client.CreateContactList(createContactList);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateContactListWrongFormatFile()
        {
            var stream = File.OpenRead("../../Files/test.png");
            var fileBytes = new byte[stream.Length];

            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();

            object[] contacts = { fileBytes };
            var createContactList = new CfCreateContactList
            {
                Validate = true,
                Name = "ContactList_Test_CreateContactListMandatory",
                ContactSource = new CfContactSource
                {
                    Items = contacts
                }
            };
            if (Client.GetType() == typeof(RestContactClient))
            {
                var id = Client.CreateContactList(createContactList);
                Assert.IsNotNull(id);
                var contactList = Client.GetContactList(id);
                Assert.AreEqual(CfContactListStatus.Errors, contactList.Status);
            }
            else
            {
                Assert.Throws<FaultException<ServiceFaultInfo>>(() => Client.CreateContactList(createContactList));
            }
        }

        /// <summary>
        /// QueryContactLists
        /// </summary>
        [Test]
        public void Test_QueryContactListsAllResults()
        {
            var contactListQueryResult = Client.QueryContactLists(new CfQuery());
            Assert.IsNotNull(contactListQueryResult);
        }

        [Test]
        public void Test_QueryContactListsComplete()
        {
            var query = new CfQuery
            {
                FirstResult = 600,
                MaxResults = 2
            };
            var contactListQueryResult = Client.QueryContactLists(query);
            Assert.IsNotNull(contactListQueryResult);
        }

        /// <summary>
        /// DeleteContactList
        /// </summary>
        
        [Test]
        public void Test_DeleteContactListInvalidId()
        {
            Client.DeleteContactList(48928984);
        }

        [Test]
        public void Test_DeleteContactListComplete()
        {
            object[] contacts = { 169299452001 };
            var createContactList = new CfCreateContactList
            {
                Name = "ContactList_Test_CreateContactListMandatoryContactId",
                ContactSource = new CfContactSource
                {
                    Items = contacts
                }
            };
            var id = Client.CreateContactList(createContactList);
            Client.DeleteContactList(id);
        }

        /// <summary>
        /// AddContactsToList
        /// </summary>
        
        [Test]
        public void Test_AddContactsToListMandatory()
        {
            object[] contacts = { 169299452001 };
            var contactListRequest = new CfContactListRequest
            {
                ContactListId = 192950001,
                ContactSource = new CfContactSource
                {
                    Items = contacts
                } 
            };
            Client.AddContactsToList(contactListRequest);
        }

        [Test]
        public void Test_AddContactsToListComplete() 
        {
            var contact1 = new CfContact
            {
                FirstName = "FirstNameContact",
                HomePhone = "14252163710"
            };

            object[] contacts = { contact1 };
            var contactListRequest = new CfContactListRequest
            {
                Validate = true,
                ContactListId = 192950001,
                ContactSource = new CfContactSource
                {
                    Items = contacts
                }
            };
            Client.AddContactsToList(contactListRequest);
        }
        
        /// <summary>
        /// GetContactList
        /// </summary>
        
        [Test]
        public void Test_GetContactListValidId()
        {
            var contactLIst = Client.GetContactList(198836001);
            Assert.IsNotNull(contactLIst);
        }

        [Test]
        public void Test_GetContactListInValidId()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetContactList(198836078));
        }
        
        /// <summary>
        /// RemoveContactsFromList
        /// </summary>
        [Test]
        public void Test_RemoveContactsFromListInvalidId() 
        {
            const int clientListId = 192950001;
            object[] contacts = { 169299452000 };
            var removeContactsFromList = new CfRemoveContactsFromList
            {
                ContactListId = clientListId,
                Item = contacts
            };
            Client.RemoveContactsFromList(removeContactsFromList);
        }

        [Test]
        public void Test_RemoveContactsFromListIdNull()
        {
            AssertClientException<WebException, FaultException>(() => Client.RemoveContactsFromList(new CfRemoveContactsFromList()));
        }

        [Test]
        public void Test_RemoveContactsFromListComplete() 
        {
            const int clientListId = 192950001;
            object[] contacts = { 169299452001 };
            var contactListRequest = new CfContactListRequest
            {
                ContactListId = clientListId,
                ContactSource = new CfContactSource
                {
                    Items = contacts
                }
            };
            Client.AddContactsToList(contactListRequest);

            var removeContactsFromList = new CfRemoveContactsFromList
            {
                ContactListId = clientListId,
                Item = contacts
            };
            Client.RemoveContactsFromList(removeContactsFromList);
        }
    }
}
