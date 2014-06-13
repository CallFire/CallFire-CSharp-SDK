using System;
using System.Linq;
using System.Net;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
{
    [TestFixture]
    public abstract class CallfireBroadcastClientTest
    {
        protected IBroadcastClient Client;
        protected CfBroadcast ExpectedBroadcast;
        protected CfBroadcast ExpectedBroadcastVoice;
        protected CfBroadcast ExpectedBroadcastText;
        protected CfQueryBroadcasts CfQueryBroadcasts;
        protected CfQueryBroadcastData QueryContactBatches;
        protected CfControlContactBatch ControlContactBatches;
        protected CfGetBroadcastStats GetBroadcastStats;
        protected CfBroadcastRequest UpdateBroadcast;
        protected CfControlBroadcast ControlBroadcast;
        protected CfCreateContactBatch CreateContactBatch;

        [Test]
        public void Test_CreateBroadcast()
        {
            var broadcastRequest = new CfBroadcastRequest("", ExpectedBroadcast);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcastNull()
        {
            var broadcastRequest = new CfBroadcastRequest("ABC", null);
            Assert.Throws<WebException>(() => Client.CreateBroadcast(broadcastRequest));
        }

        [Test]
        public void Test_CreateBroadcast_WithNameOnly()
        {
            ExpectedBroadcast = new CfBroadcast();
            ExpectedBroadcast.Name = "Name";
            //CfBroadcast
            //CfTextBroadcastConfig 

            var broadcastRequest = new CfBroadcastRequest(null, ExpectedBroadcast);
            AssertClientException(() => Client.CreateBroadcast(broadcastRequest));

        }

        private void AssertClientException(TestDelegate test)
        {
            if (Client.GetType() == typeof (RestBroadcastClient))
            {
                Assert.Throws<WebException>(test);
            }
            else
            {
                Assert.Throws<System.ServiceModel.FaultException>(test);
            }
        }

        [Test]
        public void Test_CreateBroadcast_WithNameandTypeVoice()
        {
            ExpectedBroadcast = new CfBroadcast();
            ExpectedBroadcast.Name = "Name";
            ExpectedBroadcast.Type = CfBroadcastType.Voice;
            //CfTextBroadcastConfig 

            var broadcastRequest = new CfBroadcastRequest(null, ExpectedBroadcast);
            AssertClientException(() => Client.CreateBroadcast(broadcastRequest));
        }

        [Test]
        public void Test_CreateBroadcast_VoiceBroadcastConfigFaildNumber()
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                    Item = "56",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "12"
                },
            };
            var broadcastRequest = new CfBroadcastRequest("", ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_VoiceBroadcastConfigSuccess() //mal el numero
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "4252163710",
                    Item = "56",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "12"
                },
            };
            var broadcastRequest = new CfBroadcastRequest("", ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_VoiceLocalTimeZoneRestrictionSuccess() 
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                    Item = "56",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "12",
                    //LocalTimeZoneRestriction = new LocalTimeZoneRestriction(new DateTime(2014, 01, 01, 09, 00, 00),new DateTime(2014, 01, 01, 17, 00, 00)),
                       
                },
                
            };

            var broadcastRequest = new CfBroadcastRequest("", ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }









        [Test]
        public void Test_CreateBroadcast_TextConfigSuccess()
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig()
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                   
                },
            };

            var broadcastRequest = new CfBroadcastRequest("", ExpectedBroadcastText);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }


        [Test]
        public void Test_QueryBroadcast()
        {
            var queryResult = Client.QueryBroadcasts(CfQueryBroadcasts);
            Assert.NotNull(queryResult);
            Assert.NotNull(queryResult.Broadcast);
        }

        [Test]
        public void Test_GetBroadcast()
        {
            var broadcast = Client.GetBroadcast(651);
            Assert.IsNotNull(broadcast);
            Assert.AreEqual(broadcast.Type, CfBroadcastType.Text);
        }

        [Test]
        public void Test_QueryContactBatches()
        {
            var contactBatchQueryResult = Client.QueryContactBatches(QueryContactBatches);
            Assert.IsNotNull(contactBatchQueryResult);
            Assert.IsNotNull(contactBatchQueryResult.ContactBatch);
            Assert.IsTrue(contactBatchQueryResult.ContactBatch.Any(c => c.Id.Equals(1092170001)));
        }

        [Test]
        public void Test_GetContactBatches()
        {
            var contactBatch = Client.GetContactBatch(1092170001);
            Assert.IsNotNull(contactBatch);
            Assert.AreEqual(contactBatch.Status, CfBatchStatus.Active);
            Assert.AreEqual(contactBatch.Size, 1);
        }

        [Test]
        public void Test_ControlContactBatches()
        {
            Client.ControlContactBatch(ControlContactBatches);
        }

        [Test]
        public void Test_GetBroadcastStats()
        {
            var broadcastStats = Client.GetBroadcastStats(GetBroadcastStats);
            Assert.IsNotNull(broadcastStats);
            Assert.IsNotNull(broadcastStats.ActionStatistics);
            Assert.AreEqual(broadcastStats.ActionStatistics.Unattempted, 1);
            Assert.IsNotNull(broadcastStats.UsageStats);
            Assert.AreEqual(broadcastStats.UsageStats.Duration, 0);
        }

        [Test]
        public void Test_UpdateBroadcast()
        {
            Client.UpdateBroadcast(UpdateBroadcast);
        }

        [Test]
        public void Test_ControlBroadcast()
        {
            var broadcastRequest = new CfBroadcastRequest("", ExpectedBroadcast);
            ControlBroadcast.Id = Client.CreateBroadcast(broadcastRequest);
            Client.ControlBroadcast(ControlBroadcast);
        }

        [Test]
        public void Test_CreateContactBatch()
        {
            var id = Client.CreateContactBatch(CreateContactBatch);
            Assert.IsNotNull(id);
        }
    }
}
