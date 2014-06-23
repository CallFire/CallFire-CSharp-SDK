using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
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

        protected const string VerifyFromNumber = "+19196991764";
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
        [Ignore]
        public void Test_SendCall()
        {
            var id = Client.SendCall(SendCall);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_SendCallEmpty()
        {
            AssertClientException<WebException, FaultException>(() => Client.SendCall(new CfSendCall()));
        }
        [Test]
        public void Test_SendCallMandatoryVoice() // TODO
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
        public void Test_SendCallVoiceComplete() // TODO
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
        public void Test_SendCallMandatoryIVR() //TODO
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendCall = new CfSendCall
            {
                Type = CfBroadcastType.Voice,
                ToNumber = toNumberList,
                Item = new CfIvrBroadcastConfig
                {
                    DialplanXml = "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.</play></dialplan>"
                }
            };
            var id = Client.SendCall(sendCall);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_SendCallIVRComplete() //TODO
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendCall = new CfSendCall
            {
                Type = CfBroadcastType.Voice,
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
        public void Test_QueryCalls()
        {
            var calls = Client.QueryCalls(ActionQuery);
            Assert.IsNotNull(calls);
            Assert.IsNotNull(calls.Calls);
            Assert.IsTrue(calls.Calls.Any(c => c.FromNumber.Equals("12132609784")));
            Assert.IsTrue(calls.Calls.Any(c => c.CallRecord.Any(r => r.Id.Equals(125746517001))));
        }
        
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
                BroadcastId = 1955902001,
                ToNumber = VerifyShortCode,
                MaxResults = 20,
                FirstResult = 2,
                Inbound = false,
                State = new [] {CfActionState.Invalid},
                BatchId = 1203601001,
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
            Assert.AreEqual(0, callQueryResult.TotalResults);
        }

        /// <summary>
        /// GetCall
        /// </summary>
        [Test]
        public void Test_GetCall()
        {
            var call = Client.GetCall(209720137001);
            Assert.IsNotNull(call);
            Assert.AreEqual(call.ContactId, 165251012001);
        }
        
        [Test]
        public void Test_GetCallValidId()
        {
            var call = Client.GetCall(225924967001);
            Assert.IsNotNull(call);
        }

        [Test]
        public void Test_GetCallInValidIdLetters()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetCall(48944));
        }

        //CreateSound
        [Test]
        public void Test_CreateSoundInvalidData()
        {
            //Data= file .png x example
        }

        [Test]
        public void Test_CreateSoundMandatoryFields()
        {
            //all mandatory fields complete
        }

        [Test]
        public void Test_CreateSoundNoMandatoryFields()
        {
            //all mandatory fields complete
        }
        



        


        

        

        [Test]
        public void Test_QuerySoundMeta()
        {
            var soundMeta = Client.QuerySoundMeta(QuerySoundMeta);
            Assert.IsNotNull(soundMeta);
            Assert.IsNotNull(soundMeta.SoundMeta);
            Assert.IsTrue(soundMeta.SoundMeta.Any(s => s.Id.Equals(426834001)));
        }

        [Test]
        public void Test_GetSoundMeta()
        {
            var soundMeta = Client.GetSoundMeta(426834001);
            Assert.IsNotNull(soundMeta);
            Assert.AreEqual(soundMeta.Status, CfSoundStatus.Active);
        }

        

    }
}

