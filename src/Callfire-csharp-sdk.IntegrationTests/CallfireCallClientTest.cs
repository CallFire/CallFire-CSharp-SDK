using System;
using System.IO;
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
    public abstract class CallfireCallClientTest
    {
        protected ICallClient Client;

        protected CfSendCall SendCall;
        protected CfActionQuery ActionQuery;
        protected CfQuery QuerySoundMeta;

        protected const string VerifyFromNumber = "+15712655344";
        protected const string VerifyShortCode = "67076";

        public void AssertClientException<TRest, TSoap>(TestDelegate test)
            where TRest : Exception
            where TSoap : Exception
        {
            if (Client.GetType() == typeof(RestCallClient))
            {
                Assert.Throws<TRest>(test);
            }
            else
            {
                Assert.Throws<TSoap>(test);
            }
        }

        /// <summary>
        /// SendCall
        /// </summary>
        
        [Test]
        public void Test_SendCallEmpty()
        {
            AssertClientException<WebException, FaultException>(() => Client.SendCall(new CfSendCall()));
        }

        [Test]
        public void Test_SendCallMandatoryVoice() 
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendCall = new CfSendCall
            {
                Type = CfBroadcastType.Voice,
                ToNumber = toNumberList,
                Item = new CfVoiceBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    Item = "TTS: eeee",
                    Item1 = "TTS: eeee"
                }
            };
            var id = Client.SendCall(sendCall);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_SendCallVoiceComplete() 
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendCall = new CfSendCall
            {
                Type = CfBroadcastType.Voice,
                ToNumber = toNumberList,
                ScrubBroadcastDuplicates = true,
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
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        MaxAttempts = 2,
                        MinutesBetweenAttempts = 5,
                        RetryPhoneTypes = new[] { CfRetryPhoneType.HomePhone },
                        RetryResults = new[] { CfResult.NoAns }
                    }
                }
            };
            var id = Client.SendCall(sendCall);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_SendCallMandatoryFaild() 
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendCall = new CfSendCall
            {
                Type = CfBroadcastType.Text,
                ToNumber = toNumberList,
                Item = new CfTextBroadcastConfig()
            };
            AssertClientException<WebException, CommunicationException>(() => Client.SendCall(sendCall));
        }

        [Test]
        public void Test_SendCallMandatoryIVR() 
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendCall = new CfSendCall
            {
                Type = CfBroadcastType.Ivr,
                ToNumber = toNumberList,
                Item = new CfIvrBroadcastConfig
                {
                   DialplanXml = "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.</play></dialplan>",
                   FromNumber = VerifyFromNumber
                }
            };
            var id = Client.SendCall(sendCall);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_SendCallIVRComplete()
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendCall = new CfSendCall
            {
                Type = CfBroadcastType.Ivr,
                ToNumber = toNumberList,
                ScrubBroadcastDuplicates = true,
                Item = new CfIvrBroadcastConfig
                {
                    FromNumber = VerifyFromNumber,
                    DialplanXml = "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.</play></dialplan>",
                    LocalTimeZoneRestriction = new CfLocalTimeZoneRestriction
                    {
                        BeginTime = new DateTime(2014, 01, 01, 09, 00, 00),
                        EndTime = new DateTime(2014, 01, 01, 17, 00, 00)
                    },
                    RetryConfig = new CfBroadcastConfigRetryConfig
                    {
                        MaxAttempts = 2,
                        MinutesBetweenAttempts = 5,
                        RetryPhoneTypes = new[] { CfRetryPhoneType.HomePhone },
                        RetryResults = new[] { CfResult.NoAns }
                    }
                }
            };
            var id = Client.SendCall(sendCall);
            Assert.IsNotNull(id);
        }

        /// <summary>
        /// QueryCalls
        /// </summary>
        [Test]
        public void Test_QueryCallsNotExistNumber()
        {
            var actionQuery = new CfActionQuery
            {
                ToNumber = "48945317921"
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.QueryCalls(actionQuery));
        }

        [Test]
        public void Test_QueryCallsAllResults()
        {
            var callQueryResult = Client.QueryCalls(new CfActionQuery());
            Assert.IsNotNull(callQueryResult);
        }

        [Test]
        public void Test_QueryCallsComplete()
        {
            var actionQuery = new CfActionQuery
            {
                BroadcastId = 1971748001,
                ToNumber = VerifyShortCode,
                MaxResults = 20,
                FirstResult = 2,
                Inbound = false,
                State = new [] {CfActionState.Invalid},
                BatchId = 1218740001,
                FromNumber = VerifyFromNumber,
            };
            var callQueryResult = Client.QueryCalls(actionQuery);
            Assert.IsNotNull(callQueryResult);
        }

        [Test]
        public void Test_QueryCallsInvalidBatchId()
        {
            var actionQuery = new CfActionQuery
            {
                BatchId = 1203601000,
            };
            var callQueryResult = Client.QueryCalls(actionQuery);
            Assert.IsNotNull(callQueryResult);
        }

        /// <summary>
        /// GetCall
        /// </summary>
        [Test]
        public void Test_GetCallValidId()
        {
            var call = Client.GetCall(228327782001);
            Assert.IsNotNull(call);
        }

        [Test]
        public void Test_GetCallInValidId()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetCall(48944));
        }

        /// <summary>
        /// CreateSound
        /// </summary>
        [Test]
        public void Test_CreateSoundInvalidData()
        {
            var stream = File.OpenRead("../../Files/test.png");
            
            var fileBytes = new byte[stream.Length];

            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();

            var createSound = new CfCreateSound
            {
                Item = fileBytes,
            };
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.CreateSound(createSound, CfSoundFormat.Mp3));
        }

        [Test]
        public void Test_CreateSoundMandatoryFields()
        {
            var stream = File.OpenRead("../../Files/test.mp3");
            var fileBytes = new byte[stream.Length];

            stream.Read(fileBytes, 0, fileBytes.Length);
            stream.Close();

            var createSound = new CfCreateSound
            {
                Item = fileBytes,
            };
            var id = Client.CreateSound(createSound, CfSoundFormat.Mp3);
            Assert.IsNotNull(id);
        }

        [Test]
        [Ignore]
        public void Test_CreateSoundMandatoryFieldsRecordingCall()
        {
            var createSound = new CfCreateSound
            {
                Name = "SoundRecordingCall_1",
                Item = new CfCreateSoundRecordingCall
                {
                    ToNumber = VerifyFromNumber
                },
            };
            var id = Client.CreateSound(createSound, CfSoundFormat.Mp3);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateSoundComplete()
        {
            var createSound = new CfCreateSound
            {
                Name = "SoundText_1",
                Item = "Text sound test",
                SoundTextVoice = "FEMALE1" 
            };
            var id = Client.CreateSound(createSound, CfSoundFormat.Mp3);
            Assert.IsNotNull(id);
        }

        /// <summary>
        /// QuerySoundMeta
        /// </summary>
        
        [Test]
        public void Test_QuerySoundMetaAllResults()
        {
            var soundMetaQueryResult = Client.QuerySoundMeta(new CfQuery());
            Assert.IsNotNull(soundMetaQueryResult);
        }

        [Test]
        public void Test_QuerySoundMetaSpecific()
        {
            var query = new CfQuery
            {
                FirstResult = 80,
                MaxResults = 2
            };
            var soundMetaQueryResult = Client.QuerySoundMeta(query);
            Assert.IsNotNull(soundMetaQueryResult);
        }

        /// <summary>
        /// GetSoundMeta
        /// </summary>
        
        [Test]
        public void Test_GetSoundMetaInValidId()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetSoundMeta(1568441320));
        }

        [Test]
        public void Test_GetSoundMetaValidId()
        {
            var soundMeta = Client.GetSoundMeta(459849001);
            Assert.IsNotNull(soundMeta);
        }

        /// <summary>
        /// GetSoundData
        /// </summary>
        [Test]
        public void Test_GetSoundDataMandatory()
        {
            var getSoundData = new CfGetSoundData
            {
                Id = 459849001
            };
            if (Client.GetType() == typeof (SoapCallClient))
            {
               var id = Client.GetSoundData(getSoundData);
                Assert.IsNotNull(id);
            }
        }

        [Test]
        public void Test_GetSoundDataComplete()
        {
            var getSoundData = new CfGetSoundData
            {
                Id = 459849001,
                Format = CfSoundFormat.Wav
            };
            if (Client.GetType() == typeof(SoapCallClient))
            {
                var id = Client.GetSoundData(getSoundData);
                Assert.IsNotNull(id);
            }
        }

        /// <summary>
        /// GetRecordingData
        /// </summary>
        [Test]
        public void Test_GetRecordingDataMandatory() 
        {
            object[] items = { Convert.ToInt64(2891401001) };
            var getRecordingData = new CfGetRecordingData
            {
                ItemsElementNameField = new []{CfItemsChoiceType.RecordingId},
                Items = items
            };
            if (Client.GetType() == typeof(SoapCallClient))
            {
                var recordingData = Client.GetRecordingData(getRecordingData);
                Assert.IsNotNull(recordingData);
            }
        }

        [Test]
        public void Test_GetRecordingDataComplete()
        {
            object[] items = { Convert.ToInt64(230484476001), "recording" };
            var getRecordingData = new CfGetRecordingData
            {
                Format = CfSoundFormat.Mp3,
                ItemsElementNameField = new[] { CfItemsChoiceType.CallId, CfItemsChoiceType.Name },
                Items = items
            };
            if (Client.GetType() == typeof(SoapCallClient))
            {
                var recordingData = Client.GetRecordingData(getRecordingData);
                Assert.IsNotNull(recordingData);
            }
        }

        [Test]
        public void Test_GetRecordingDataRecordingIdInvalid() 
        {
            object[] items = { Convert.ToInt64(137448938001) };
            var getRecordingData = new CfGetRecordingData
            {
                ItemsElementNameField = new[] { CfItemsChoiceType.RecordingId },
                Items = items
            };
            if (Client.GetType() == typeof (SoapCallClient))
            {
                Assert.Throws<FaultException<ServiceFaultInfo>>(() => Client.GetRecordingData(getRecordingData));
            }
        }

        [Test]
        public void Test_GetRecordingDataRecordingDifferentName()
        {
            object[] items = { Convert.ToInt64(137448938001), "Name" };
            var getRecordingData = new CfGetRecordingData
            {
                ItemsElementNameField = new[] { CfItemsChoiceType.CallId, CfItemsChoiceType.Name, CfItemsChoiceType.RecordingId },
                Items = items
            };
            if (Client.GetType() == typeof(SoapCallClient))
            {
                Assert.Throws<FaultException>(() => Client.GetRecordingData(getRecordingData));
            }
        }
    }
}

