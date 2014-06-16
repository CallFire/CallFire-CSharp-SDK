using System;
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
    public abstract class CallfireBroadcastClientTest
    {
        protected IBroadcastClient Client;
        protected CfBroadcast ExpectedBroadcastDefault;
        protected CfBroadcast ExpectedBroadcast;
        protected CfBroadcast ExpectedBroadcastVoice;
        protected CfBroadcast ExpectedBroadcastText;
        protected CfBroadcast ExpectedBroadcastIvr;
        protected CfQueryBroadcasts CfQueryBroadcasts;
        protected CfQueryBroadcastData QueryContactBatches;
        protected CfControlContactBatch ControlContactBatches;
        protected CfGetBroadcastStats GetBroadcastStats;
        protected CfBroadcastRequest UpdateBroadcast;
        protected CfControlBroadcast ControlBroadcast;
        protected CfCreateContactBatch CreateContactBatch;

        private void AssertClientException<TRest, TSoap>(TestDelegate test) 
            where TRest : Exception 
            where TSoap : Exception
        {
            if (Client.GetType() == typeof(RestBroadcastClient))
            {
                Assert.Throws<TRest>(test);
            }
            else
            {
                Assert.Throws<TSoap>(test);
            }
        }

        [Test]
        public void Test_CreateBroadcast()
        {
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastDefault);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcastNull()
        {
            var broadcastRequest = new CfBroadcastRequest(string.Empty, null);
            AssertClientException<WebException, FaultException>(() => Client.CreateBroadcast(broadcastRequest));
        }

        [Test]
        public void Test_CreateBroadcast_WithNameOnly()
        {
            ExpectedBroadcast = new CfBroadcast
            {
                Name = "Name"
            };

            var broadcastRequest = new CfBroadcastRequest(null, ExpectedBroadcast);
            AssertClientException<WebException, FaultException>(() => Client.CreateBroadcast(broadcastRequest));
        }

        [Test]
        public void Test_CreateBroadcast_WithNameandTypeVoice()
        {
            ExpectedBroadcast = new CfBroadcast
            {
                Name = "Name", 
                Type = CfBroadcastType.Voice
            };

            var broadcastRequest = new CfBroadcastRequest(null, ExpectedBroadcast);
            AssertClientException<WebException, FaultException>(() => Client.CreateBroadcast(broadcastRequest));
        }

        //VOICE BROADCAST 
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
                    FromNumber = "45879163710",
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee"
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.CreateBroadcast(broadcastRequest));
        }

        [Test]
        public void Test_CreateBroadcast_VoiceBroadcastConfigComplete() // not a valid from number
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "67076",
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee",
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_VoiceLocalTimeZoneRestrictionComplete() // not a valid from number
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "67076",
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee",
                    LocalTimeZoneRestriction = new CfLocalTimeZoneRestriction
                    {
                        BeginTime = new DateTime(2014, 01, 01, 09, 00, 00),
                        EndTime = new DateTime(2014, 01, 01, 17, 00, 00)
                    },
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_VoiceLocalTimeZoneRestrictionBeginTimeOnly() // not a valid from number
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
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee",
                    LocalTimeZoneRestriction = new CfLocalTimeZoneRestriction
                    {
                        BeginTime = new DateTime(2014, 01, 01, 09, 00, 00),
                    },
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }
        
        [Test]
        public void Test_CreateBroadcast_VoiceRetryConfigMandatoryFieldsOnlyComplete() // not a valid from number
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
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryResults = new[] { CfResult.Received }
                    }
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_VoiceRetryConfigCompleteItem_Item1_Item2_Item3Long()//Error interno del servidor.
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    //Id = 1,
                    //Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                    Item = 426834001,
                    //MachineSoundTextVoice = "SPANISH1",
                    //Item1 = 426834001,
                    //RetryConfig = new CfBroadcastConfigRetryConfig
                    //{
                    //    RetryResults = new[] { CfResult.Received }
                    //}
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_VoiceRetryConfigComplete() // not a valid from number
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
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        MaxAttempts = 2,
                        MinutesBetweenAttempts = 5,
                        RetryPhoneTypes = new[] { CfRetryPhoneType.HomePhone },
                        RetryResults = new[] { CfResult.Received }
                    }
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }
       
        [Test]
        public void Test_CreateBroadcast_VoiceRetryConfigNotAllComplete() // not a valid from number
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
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        MaxAttempts = 2,
                        MinutesBetweenAttempts = 5,
                    }
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.CreateBroadcast(broadcastRequest));
        }

        [Test]
        public void Test_CreateBroadcast_VoiceRetryConfigMandatoryFieldInvalid() // not a valid from number
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
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        MaxAttempts = 2,
                        MinutesBetweenAttempts = 5,
                        RetryResults = null
                    }
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.CreateBroadcast(broadcastRequest));
        }

        //TEXT BROADCAST
        [Test]
        public void Test_CreateBroadcast_TextLocalTimeZoneRestrictionEndTimeOnly() //invalid from number
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                    LocalTimeZoneRestriction = new CfLocalTimeZoneRestriction
                    {
                        EndTime = new DateTime(2014, 01, 01, 17, 00, 00)
                    },
                    Message = "Message Test",
                    BigMessageStrategy = CfBigMessageStrategy.DoNotSend
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastText);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_TextRetryConfigMandatoryFieldsOnlyComple() //invalid from number
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryPhoneTypes = new[] { CfRetryPhoneType.HomePhone },
                    },
                    Message = "Message Test",
                    BigMessageStrategy = CfBigMessageStrategy.DoNotSend
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastText);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_TextRetryConfigNotAllComplete() //invalid from number
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryPhoneTypes = new[] { CfRetryPhoneType.FirstNumber },
                        RetryResults = new[] { CfResult.NoAns }
                    },
                    Message = "Message Test",
                    BigMessageStrategy = CfBigMessageStrategy.Trim
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastText);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }
        
        [Test]
        public void Test_CreateBroadcast_TextRetryConfigMessage160caracters()//invalid from number
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                    Message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adineque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adi",
                    BigMessageStrategy = CfBigMessageStrategy.SendMultiple
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastText);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_TextRetryConfigMessage161caractersANDRetryResultsSENT() //invalid from number
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryPhoneTypes = new[] { CfRetryPhoneType.FirstNumber },
                        RetryResults = new[] { CfResult.Sent }
                    },
                    Message = "Xneque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adineque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adi",
                    BigMessageStrategy = CfBigMessageStrategy.DoNotSend
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastText);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        //IVR
        [Test]
        public void Test_CreateBroadcast_IvrBroadcastConfigFaildId() //not a valid from number
        {
            ExpectedBroadcastIvr = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Ivr,
                Item = new CfIvrBroadcastConfig
                {
                    Id = -1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                    DialplanXml = "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.</play></dialplan>"
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastIvr);
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
                Item = new CfTextBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = "14252163710",
                },
            };

            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastText);
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
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastDefault);
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
