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

        protected const string VerifyFromNumber = "+15712655344";
        protected const string VerifyShortCode = "67076";
        protected const long ExistingBroadcastId = 1931347001;

        public void AssertClientException<TRest, TSoap>(TestDelegate test)
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

        /// <summary>
        /// Create Broadcasts
        /// </summary>
        
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

        /// <summary>
        /// Create Voice Broadcasts
        /// </summary>
        [Test]
        public void Test_CreateBroadcast_VoiceBroadcastConfigFaildNumber() 
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
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
        public void Test_CreateBroadcast_VoiceBroadcastConfigComplete() 
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
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
        public void Test_CreateBroadcast_VoiceLocalTimeZoneRestrictionComplete() 
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
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
        public void Test_CreateBroadcast_VoiceLocalTimeZoneRestrictionBeginTimeOnly() 
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
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
            if (Client.GetType() == typeof (RestBroadcastClient))
            {
                var id = Client.CreateBroadcast(broadcastRequest);
                Assert.IsNotNull(id);
            }
            else
            {
                Assert.Throws<FaultException<ServiceFaultInfo>>(() => Client.CreateBroadcast(broadcastRequest));
            }
        }

        [Test]
        public void Test_CreateBroadcast_VoiceRetryConfigCompleteItem_Item1_Item2_Item3Long()
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    Item = 460760001,
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = 460760001,
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryResults = new[] { CfResult.La }
                    }
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_VoiceRetryConfigComplete()
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        MaxAttempts = 2,
                        MinutesBetweenAttempts = 5,
                        RetryPhoneTypes = new[] { CfRetryPhoneType.HomePhone },
                        RetryResults = new[] { CfResult.NoAns }
                    }
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }
       
        [Test]
        public void Test_CreateBroadcast_VoiceRetryConfigNotAllComplete() 
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee",
                    RetryConfig = new CfBroadcastConfigRetryConfig()
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        /// <summary>
        /// Create Text Broadcast
        /// </summary>
        [Test]
        public void Test_CreateBroadcast_TextConfigSuccess()
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    FromNumber = VerifyShortCode,
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryPhoneTypes = new[] { CfRetryPhoneType.FirstNumber },
                        RetryResults = new[] { CfResult.NoAns }
                    },
                    Message = "Message Test",
                },
            };

            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastText);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_TextLocalTimeZoneRestrictionEndTimeOnly() 
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    FromNumber = VerifyShortCode,
                    LocalTimeZoneRestriction = new CfLocalTimeZoneRestriction
                    {
                        EndTime = new DateTime(2014, 01, 01, 17, 00, 00)
                    },
                    Message = "Message Test",
                    BigMessageStrategy = CfBigMessageStrategy.DoNotSend
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastText);
            if (Client.GetType() == typeof(RestBroadcastClient))
            {
                var id = Client.CreateBroadcast(broadcastRequest);
                Assert.IsNotNull(id);
            }
            else
            {
                Assert.Throws<FaultException<ServiceFaultInfo>>(() => Client.CreateBroadcast(broadcastRequest));
            }
        }

        [Test]
        public void Test_CreateBroadcast_TextRetryConfigNotAllComplete() 
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    FromNumber = VerifyShortCode,
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
        public void Test_CreateBroadcast_TextRetryConfigMessage160caracters()
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    Id = 1,
                    Created = new DateTime(2012, 10, 26),
                    FromNumber = VerifyShortCode,
                    Message = "Neque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adineque porro quisquam est qui dolorem ipsum quia dolor sit amet, consectetur, adi",
                    BigMessageStrategy = CfBigMessageStrategy.SendMultiple
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastText);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_TextRetryConfigMessage161caractersANDRetryResultsSENT() 
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    FromNumber = VerifyShortCode,
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

        /// <summary>
        /// Create Ivr Broadcast
        /// </summary>
        [Test]
        public void Test_CreateBroadcast_IvrBroadcastConfigComplete()
        {
            ExpectedBroadcastIvr = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Ivr,
                Item = new CfIvrBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    DialplanXml = "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.</play></dialplan>"
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastIvr);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_IvrLocalTimeZoneRestrictionComplete()
        {
            ExpectedBroadcastIvr = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Ivr,
                Item = new CfIvrBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    DialplanXml = "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.</play></dialplan>",
                    LocalTimeZoneRestriction = new CfLocalTimeZoneRestriction
                    {
                        BeginTime = new DateTime(2014, 01, 01, 09, 00, 00),
                        EndTime = new DateTime(2014, 01, 01, 17, 00, 00)
                    }
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastIvr);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_IvrRetryConfigNODialplanXml()
        {
            ExpectedBroadcastIvr = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Ivr,
                Item = new CfIvrBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryPhoneTypes = new[] { CfRetryPhoneType.FirstNumber },
                        RetryResults = new[] { CfResult.TooBig }
                    },
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastIvr);
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.CreateBroadcast(broadcastRequest));
        }

        [Test]
        public void Test_CreateBroadcast_IvrRetryConfigVALIDDialplanXml()
        {
            ExpectedBroadcastIvr = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Ivr,
                Item = new CfIvrBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    DialplanXml = "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.</play></dialplan>",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryPhoneTypes = new[] { CfRetryPhoneType.WorkPhone },
                        RetryResults = new[] { CfResult.InternalError }
                    },
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastIvr);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateBroadcast_IvrRetryConfigINVALIDDialplanXml()
        {
            ExpectedBroadcastIvr = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Ivr,
                Item = new CfIvrBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    DialplanXml = "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        RetryPhoneTypes = new[] { CfRetryPhoneType.WorkPhone },
                        RetryResults = new[] { CfResult.CarrierError }
                    },
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastIvr);
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.CreateBroadcast(broadcastRequest));
        }

        [Test]
        public void Test_CreateBroadcast_IvrRetryConfigNotallComplete()
        {
            ExpectedBroadcastIvr = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Ivr,
                Item = new CfIvrBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    DialplanXml = "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.</play></dialplan>",
                    RetryConfig = new CfBroadcastConfigRetryConfig()
                },
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastIvr);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        /// <summary>
        /// QueryBroadcasts
        /// </summary>
       [Test]
        public void Test_QueryBroadcastsEmpty()
        {
            var broadcastQueryResult = Client.QueryBroadcasts(new CfQueryBroadcasts{MaxResults = 100});
            Assert.IsNotNull(broadcastQueryResult);
        }

        [Test]
        public void Test_QueryBroadcastsCompleteTrue()
        {
            var cfQueryBroadcasts = new CfQueryBroadcasts
            {
                FirstResult = 1,
                MaxResults = 50,
                Type = new[] {CfBroadcastType.Voice},
                Running = true
            };
            var broadcastQueryResult = Client.QueryBroadcasts(cfQueryBroadcasts);
            Assert.IsNotNull(broadcastQueryResult);
        }

        [Test]
        public void Test_QueryBroadcastsCompleteFalse()
        {
            var cfQueryBroadcasts = new CfQueryBroadcasts
            {
                MaxResults = 50,
                Type = new[] { CfBroadcastType.Text },
                Running = true
            };
            var broadcastQueryResult = Client.QueryBroadcasts(cfQueryBroadcasts);
            Assert.IsNotNull(broadcastQueryResult);
        }

        /// <summary>
        /// GetBroadcast
        /// </summary>
        
        [Test]
        public void Test_GetBroadcastSuccess()
        {
            var broadcast = Client.GetBroadcast(1934539001);
            Assert.IsNotNull(broadcast);
        }

        /// <summary>
        /// Update Broadcast
        /// </summary>
        [Test]
        public void Test_UpdateBroadcastChangeTypeVoice()
        {
            ExpectedBroadcastVoice = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    Item = "TTS: eeee",
                    MachineSoundTextVoice = "SPANISH1",
                    Item1 = "TTS: eeee",
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        MaxAttempts = 2,
                        MinutesBetweenAttempts = 5,
                        RetryPhoneTypes = new[] { CfRetryPhoneType.HomePhone },
                        RetryResults = new[] { CfResult.NoAns }
                    }
                },
            };
            var id = Client.CreateBroadcast(new CfBroadcastRequest(string.Empty, ExpectedBroadcastVoice));

            const string newName = "changeType";
            const long newSoundId = 460759001;
            const int newMaxAttempts = 10;
            ExpectedBroadcast = new CfBroadcast
            {
                Id = id,
                Name = newName,
                Type = CfBroadcastType.Voice,
                Item = new CfVoiceBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    Item = newSoundId,
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        MaxAttempts = newMaxAttempts,
                        RetryPhoneTypes = new[] { CfRetryPhoneType.MobilePhone },
                    }
                },
            };
            Client.UpdateBroadcast(new CfBroadcastRequest(string.Empty, ExpectedBroadcast));
            var broadcast = Client.GetBroadcast(id);

            Assert.AreEqual(newName, broadcast.Name);
            Assert.AreEqual(newSoundId, ((CfVoiceBroadcastConfig)broadcast.Item).Item);
            Assert.AreEqual(newMaxAttempts, broadcast.Item.RetryConfig.MaxAttempts);
            Assert.IsTrue(broadcast.Item.RetryConfig.RetryPhoneTypes.Any(t => t.Equals(CfRetryPhoneType.MobilePhone)));
        }

        [Test]
        public void Test_UpdateBroadcastChangeTypeText()
        {
            ExpectedBroadcastText = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    FromNumber = VerifyShortCode,
                    RetryConfig = new CfBroadcastConfigRetryConfig(),
                    Message = "Message Test",
                    BigMessageStrategy = CfBigMessageStrategy.DoNotSend
                },
            };

            var id = Client.CreateBroadcast(new CfBroadcastRequest(string.Empty, ExpectedBroadcastText));

            const string newName = "changeTypeText";
            const string newMessage = "UpdateMessage";
            const CfBigMessageStrategy newBigMessageStrategy = CfBigMessageStrategy.SendMultiple;
           
            ExpectedBroadcast = new CfBroadcast
            {
                Id = id,
                Name = newName,
                Type = CfBroadcastType.Text,
                Item = new CfTextBroadcastConfig
                {
                    FromNumber = VerifyShortCode,
                    Message = newMessage,
                    BigMessageStrategy = newBigMessageStrategy
                },
            };
            Client.UpdateBroadcast(new CfBroadcastRequest(string.Empty, ExpectedBroadcast));
            var broadcast = Client.GetBroadcast(id);

            Assert.AreEqual(newName, broadcast.Name);
            Assert.AreEqual(newMessage, ((CfTextBroadcastConfig)broadcast.Item).Message);
            Assert.AreEqual(newBigMessageStrategy, ((CfTextBroadcastConfig)broadcast.Item).BigMessageStrategy);
        }

        [Test]
        public void Test_UpdateBroadcastChangeTypeIVR()
        {
            ExpectedBroadcastIvr = new CfBroadcast
            {
                Name = "Name",
                Type = CfBroadcastType.Ivr,
                Item = new CfIvrBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    DialplanXml =
                        "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.</play></dialplan>",
                    RetryConfig = new CfBroadcastConfigRetryConfig(),
                },
            };
            var id = Client.CreateBroadcast(new CfBroadcastRequest(string.Empty, ExpectedBroadcastIvr));

            const string newName = "changeTypeIVR";
            const string newDialplanXml = "<dialplan><play type=\"tts\">Updated DialplanXml</play></dialplan>";
            ExpectedBroadcast = new CfBroadcast
            {
                Id = id,
                Name = newName,
                Type = CfBroadcastType.Ivr,
                Item = new CfIvrBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    DialplanXml = newDialplanXml,
                },
            };

            Client.UpdateBroadcast(new CfBroadcastRequest(string.Empty, ExpectedBroadcast));
            var broadcast = Client.GetBroadcast(id);

            Assert.AreEqual(newName, broadcast.Name);
            Assert.AreEqual(newDialplanXml, ((CfIvrBroadcastConfig) broadcast.Item).DialplanXml);
        }

        [Test]
        public void Test_UpdateBroadcastChangeTypeINVALID()
        {
            ExpectedBroadcast = new CfBroadcast
            {
                Id = 789,
                Name = "changeType",
                Type = CfBroadcastType.Ivr,
                Item = new CfIvrBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    DialplanXml = "<dialplan><play type=\"tts\">Fail Updated DialplanXml</play></dialplan>",
                },
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.UpdateBroadcast(new CfBroadcastRequest(string.Empty, ExpectedBroadcast)));
        }

        /// <summary>
        /// GetBroadcastStats
        /// </summary>
        
        [Test]
        public void Test_GetBroadcastStatsComplete()
        {
            var getBroadcastStats = new CfGetBroadcastStats
            {
                Id = 1934513001,
                IntervalBegin = new DateTime(2014, 01, 01, 00, 00, 01),
                IntervalEnd = new DateTime(2014, 12, 31, 23, 59, 59)
            };
            var broadcastStats = Client.GetBroadcastStats(getBroadcastStats);
            Assert.IsNotNull(broadcastStats);
        }

        [Test]
        public void Test_GetBroadcastStatsIncomplete()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetBroadcastStats(new CfGetBroadcastStats()));
        }

        /// <summary>
        /// ControlBroadcast
        /// </summary>
        
        [Test]
        public void Test_ControlBroadcastStart()
        {
            var controlBroadcast = new CfControlBroadcast
            {
                Command = CfBroadcastCommand.Start
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastDefault);
            controlBroadcast.Id = Client.CreateBroadcast(broadcastRequest);

            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.ControlBroadcast(controlBroadcast));
        }

        [Test]
        public void Test_ControlBroadcastStop()
        {
            var controlBroadcast = new CfControlBroadcast
            {
                Command = CfBroadcastCommand.Stop
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastDefault);
            controlBroadcast.Id = Client.CreateBroadcast(broadcastRequest);

            Client.ControlBroadcast(controlBroadcast);
            var broadcast = Client.GetBroadcast(controlBroadcast.Id);
            Assert.AreEqual(CfBroadcastStatus.Stopped, broadcast.Status);
        }

        [Test]
        public void Test_ControlBroadcastArchive()
        {
            var controlBroadcast = new CfControlBroadcast
            {
                Command = CfBroadcastCommand.Archive
            };
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastDefault);
            controlBroadcast.Id = Client.CreateBroadcast(broadcastRequest);

            Client.ControlBroadcast(controlBroadcast);
            var broadcast = Client.GetBroadcast(controlBroadcast.Id);
            Assert.AreEqual(CfBroadcastStatus.Archived, broadcast.Status);
        }

        [Test]
        public void Test_ControlBroadcastInvalidID()
        {
            var controlBroadcast = new CfControlBroadcast
            {
                Command = CfBroadcastCommand.Start
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.ControlBroadcast(controlBroadcast));
        }

        /// <summary>
        /// CreateContactBatch
        /// </summary>
        [Test]
        public void Test_CreateContactBatchBroadcastId()
        {
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastDefault);
            var id = Client.CreateBroadcast(broadcastRequest);

            object[] contactListId = { Convert.ToInt64(192949001) };
            var createContactBatch = new CfCreateContactBatch
            {
                BroadcastId = id,
                Name = "Test Contact Batch",
                Items = contactListId,
                ScrubBroadcastDuplicates = false
            };
            var idContactBatch = Client.CreateContactBatch(createContactBatch);
            Assert.NotNull(idContactBatch);
        }

        [Test]
        public void Test_CreateContactBatchComplete()
        {
            var broadcastRequest = new CfBroadcastRequest(string.Empty, ExpectedBroadcastDefault);
            var id = Client.CreateBroadcast(broadcastRequest);

            object[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" },
                                      new CfToNumber { Value = VerifyShortCode,  ClientData = "Client2" }};
            var createContactBatch = new CfCreateContactBatch
            {
                BroadcastId = id,
                Name = "Test Contact Batch",
                Items = toNumberList,
                ScrubBroadcastDuplicates = true
            };
            var idContactBatch = Client.CreateContactBatch(createContactBatch);
            Assert.NotNull(idContactBatch);
        }

        [Test]
        public void Test_CreateContactBatchInComplete()
        {
            var createContactBatch = new CfCreateContactBatch
            {
                Name = "Test Contact Batch",
                ScrubBroadcastDuplicates = false
            };
            AssertClientException<WebException, FaultException>(() => Client.CreateContactBatch(createContactBatch));
        }

        /// <summary>
        /// QueryContactBatches
        /// </summary>
        [Test]
        public void Test_QueryContactBatchesAllResults()
        {
            var queryBroadcastData = new CfQueryBroadcastData
            {
                BroadcastId = ExistingBroadcastId
            };
            var contactBatchQueryResult = Client.QueryContactBatches(queryBroadcastData);
            Assert.IsNotNull(contactBatchQueryResult);
        }
        
        [Test]
        public void Test_QueryContactBatchesComplete()
        {
            var queryBroadcastData = new CfQueryBroadcastData
            {
                BroadcastId = ExistingBroadcastId,
                MaxResults = 20,
                FirstResult = 2
            };
            var contactBatchQueryResult = Client.QueryContactBatches(queryBroadcastData);
            Assert.IsNotNull(contactBatchQueryResult);
        }

        /// <summary>
        /// GetContactBatches
        /// </summary>
        [Test]
        public void Test_GetContactBatchesValidId()
        {
            var contactBatch = Client.GetContactBatch(1092170001);
            Assert.IsNotNull(contactBatch);
            Assert.AreEqual(contactBatch.Status, CfBatchStatus.Active);
            Assert.AreEqual(contactBatch.Size, 1);
        }
        
        [Test]
        public void Test_GetContactBatchesInValidId()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetContactBatch(1092170000));
        }

        /// <summary>
        /// ControlContactBatches
        /// </summary>
        
        [Test]
        public void Test_ControlContactBatchesCompleteTrue()
        {
            var controlContactBatch = new CfControlContactBatch
            {
                Id = 1199291001,
                Enabled = true,
                Name = "Enabled Contact Batch Enabled"
            };
            Client.ControlContactBatch(controlContactBatch);
        }

        [Test]
        public void Test_ControlContactBatchesCompleteFalse()
        {
            var controlContactBatch = new CfControlContactBatch
            {
                Id = 1199291001,
                Enabled = false,
                Name = "Disabled Contact Batch"
            };
            Client.ControlContactBatch(controlContactBatch);
        }

        /// <summary>
        /// CreateBroadcastSchedule
        /// </summary>
        [Test]
        public void Test_CreateBroadcastScheduleMandatory()
        {
            var createBroadcastSchedule = new CfCreateBroadcastSchedule
            {
                BroadcastId = 1931347001,
                BroadcastSchedule = new CfBroadcastSchedule
                {
                    StartTimeOfDay = new DateTime(2014,01,01,08,00,00),
                    StopTimeOfDay = new DateTime(2014,01,01,20,00,00),
                    TimeZone = "America/Edmonton"
                }
            };
            var id = Client.CreateBroadcastSchedule(createBroadcastSchedule);
            Assert.NotNull(id);
        }

        [Test]
        public void Test_CreateBroadcastScheduleComplete()
        {
            var createBroadcastSchedule = new CfCreateBroadcastSchedule
            {
                BroadcastId = 1931347001,
                BroadcastSchedule = new CfBroadcastSchedule
                {
                    BeginDate = new DateTime(2014, 06, 18, 00, 00, 00),
                    EndDate = new DateTime(2014, 07, 18, 00, 00, 00),
                    StartTimeOfDay = new DateTime(2014, 01, 01, 13, 00, 00),
                    StopTimeOfDay = new DateTime(2014, 01, 01, 20, 00, 00),
                    TimeZone = "America/Edmonton",
                    DaysOfWeek = new [] { CfDaysOfWeek.Monday, CfDaysOfWeek.Sunday }
                }
            };
            var id = Client.CreateBroadcastSchedule(createBroadcastSchedule);
            Assert.NotNull(id);
        }

        /// <summary>
        /// QueryBroadcastSchedule
        /// </summary>
        [Test]
        public void Test_QueryBroadcastScheduleBroadcastId()
        {
            var queryBroadcastData = new CfQueryBroadcastData
            {
                BroadcastId = 1934539001
            };
            var broadcastScheduleQueryResult = Client.QueryBroadcastSchedule(queryBroadcastData);
            Assert.IsNotNull(broadcastScheduleQueryResult);
        }

        [Test]
        public void Test_QueryBroadcastScheduleComplete()
        {
            var queryBroadcastData = new CfQueryBroadcastData
            {
                BroadcastId = ExistingBroadcastId,
                FirstResult = 1,
                MaxResults = 10
            };
            var broadcastScheduleQueryResult = Client.QueryBroadcastSchedule(queryBroadcastData);
            Assert.IsNotNull(broadcastScheduleQueryResult);
        }

        /// <summary>
        /// GetBroadcastSchedule
        /// </summary>
        [Test]
        public void Test_GetBroadcastScheduleValidId()
        {
            var broadcastSchedule = Client.GetBroadcastSchedule(58373001);
            Assert.IsNotNull(broadcastSchedule);
        }

        [Test]
        public void Test_GetBroadcastScheduleInvalidID()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetBroadcastSchedule(58373000));
        }

        /// <summary>
        /// DeleteBroadcastSchedule
        /// </summary>
        [Test]
        public void Test_DeleteBroadcastScheduleValidID()
        {
             var createBroadcastSchedule = new CfCreateBroadcastSchedule
            {
                BroadcastId = 1934511001,
                BroadcastSchedule = new CfBroadcastSchedule
                {
                    StartTimeOfDay = new DateTime(2014,01,01,08,00,00),
                    StopTimeOfDay = new DateTime(2014,01,01,20,00,00),
                    TimeZone = "America/Edmonton"
                }
            };
            var id = Client.CreateBroadcastSchedule(createBroadcastSchedule);
            Client.DeleteBroadcastSchedule(id);
        }

        [Test]
        public void Test_DeleteBroadcastScheduleInvalidID()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.DeleteBroadcastSchedule(58378000));
        }
    }
}
