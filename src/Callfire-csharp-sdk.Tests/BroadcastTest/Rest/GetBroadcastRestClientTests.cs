using System;
using CallFire_csharp_sdk.API.Rest.BroadcastRest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class GetBroadcastRestClientTests : GetBroadcastClientTests
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);

            BroadcastName = "broadcast1";
            BroadcastLastModified = DateTime.Now;

            CreateExpectedBroadcast(1, BroadcastName, CfBroadcastStatus.Running, BroadcastLastModified, CfBroadcastType.Text, null);

            ConfigId = 1;
            ConfigCreated = DateTime.Now;
            ConfigFromNumber = "fromNumber";
            ConfigBeginTime = DateTime.Now;
            ConfigEndTime = DateTime.Now;
            ConfigMaxAttempts = 1000;
            ConfigMinutesBetweenAttempts = 2;
            ConfigRetryResults = "retryResult";
            ConfigRetryPhoneTypes = "retryPhoneTypes";

            TextConfigMessage = "Message";

            var localTimeZoneRestriction = new CfLocalTimeZoneRestriction(ConfigBeginTime, ConfigEndTime);
            var broadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(ConfigMaxAttempts, ConfigMinutesBetweenAttempts, ConfigRetryResults, ConfigRetryPhoneTypes);
            var textBroadcastConfig = new CfTextBroadcastConfig(ConfigId, ConfigCreated, ConfigFromNumber, null, broadcastConfigRestryConfig, TextConfigMessage, CfBigMessageStrategy.SendMultiple);
            CreateExpectedBroadcast(2, BroadcastName, CfBroadcastStatus.Running, BroadcastLastModified, CfBroadcastType.Text, textBroadcastConfig);

            textBroadcastConfig = new CfTextBroadcastConfig(ConfigId, ConfigCreated, ConfigFromNumber, localTimeZoneRestriction, null, TextConfigMessage, CfBigMessageStrategy.SendMultiple);
            CreateExpectedBroadcast(3, BroadcastName, CfBroadcastStatus.Running, BroadcastLastModified, CfBroadcastType.Text, textBroadcastConfig);

            IvrConfigDialplanXml = "dialplanXml";
            var ivrBroadcastConfig = new CfIvrBroadcastConfig(ConfigId, ConfigCreated,
                ConfigFromNumber, localTimeZoneRestriction, broadcastConfigRestryConfig, IvrConfigDialplanXml);
            CreateExpectedBroadcast(4, BroadcastName, CfBroadcastStatus.Running, BroadcastLastModified, CfBroadcastType.Ivr, ivrBroadcastConfig);

            VoiceConfigItem = "item";
            VoiceConfigLiveSoundTextVoice = "liveSoundTextVoice";
            VoiceConfigItem1 = "item1";
            VoiceConfigMachineSoundTextVoice = "machineSoundTextVoice";
            VoiceConfigItem2 = "item2";
            VoiceConfigTransferSoundTextVoice = "tranferSoudnTextVoice";
            VoiceConfigTransferDigit = "1";
            VoiceConfigTransferNumber = "123456";
            VoiceConfigItem3 = "item3";
            VoiceConfigDncSoundTextVoice = "DncSoundTextVoice";
            VoiceConfigDncDigit = "1";
            VoiceConfigMaxActiveTransfers = 5;
            var voiceBroadcastConfig = new CfVoiceBroadcastConfig(ConfigId, ConfigCreated,
                ConfigFromNumber, localTimeZoneRestriction, broadcastConfigRestryConfig,
                CfAnsweringMachineConfig.AmAndLive, VoiceConfigItem, VoiceConfigLiveSoundTextVoice, VoiceConfigItem1,
                VoiceConfigMachineSoundTextVoice, VoiceConfigItem2, VoiceConfigTransferSoundTextVoice, VoiceConfigTransferDigit,
                VoiceConfigTransferNumber, VoiceConfigItem3, VoiceConfigDncSoundTextVoice, VoiceConfigDncDigit,
                VoiceConfigMaxActiveTransfers);
            CreateExpectedBroadcast(5, BroadcastName, CfBroadcastStatus.Running, BroadcastLastModified, CfBroadcastType.Voice, voiceBroadcastConfig);
        }

        private void CreateExpectedBroadcast(long broadcastId, string broadcastName, CfBroadcastStatus broadcastStatus, DateTime broadcastLastModified, CfBroadcastType broadcastType, CfBroadcastConfig broadcastCongif)
        {
            var expectedBroadcast = BroadcastMapper.ToSoapBroadcast(new CfBroadcast(broadcastId, broadcastName, broadcastStatus, broadcastLastModified, broadcastType, broadcastCongif));

            JsonServiceClientMock
                .Stub(j => j.Send<Broadcast>(Arg<string>.Is.Equal(HttpMethods.Get), 
                    Arg<string>.Is.Equal(String.Format("/broadcast/{0}", broadcastId)),
                    Arg<object>.Is.Null))
                .Return(expectedBroadcast);
        }
    }
}
