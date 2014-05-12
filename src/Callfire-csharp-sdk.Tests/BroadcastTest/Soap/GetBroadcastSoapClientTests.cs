using System;
using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class GetBroadcastSoapClientTests : GetBroadcastClientTests
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);
            BroadcastName = "broadcast1";
            BroadcastLastModified = DateTime.Now;

            CreateExpectedBroadcast(1, BroadcastName, BroadcastStatus.RUNNING, BroadcastLastModified, BroadcastType.TEXT, null);

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

            var localTimeZoneRestriction = new LocalTimeZoneRestriction(ConfigBeginTime, ConfigEndTime);
            var broadcastConfigRestryConfig = new BroadcastConfigRetryConfig(ConfigMaxAttempts, ConfigMinutesBetweenAttempts, ConfigRetryResults, ConfigRetryPhoneTypes);
            var textBroadcastConfig = new TextBroadcastConfig(ConfigId, ConfigCreated, ConfigFromNumber, null, broadcastConfigRestryConfig, TextConfigMessage, BigMessageStrategy.SEND_MULTIPLE);
            CreateExpectedBroadcast(2, BroadcastName, BroadcastStatus.RUNNING, BroadcastLastModified, BroadcastType.TEXT, textBroadcastConfig);
            
            textBroadcastConfig = new TextBroadcastConfig(ConfigId, ConfigCreated, ConfigFromNumber, localTimeZoneRestriction, null, TextConfigMessage, BigMessageStrategy.SEND_MULTIPLE);
            CreateExpectedBroadcast(3, BroadcastName, BroadcastStatus.RUNNING, BroadcastLastModified, BroadcastType.TEXT, textBroadcastConfig);

            IvrConfigDialplanXml = "dialplanXml";
            var ivrBroadcastConfig = new IvrBroadcastConfig(ConfigId, ConfigCreated,
                ConfigFromNumber, localTimeZoneRestriction, broadcastConfigRestryConfig, IvrConfigDialplanXml);
            CreateExpectedBroadcast(4, BroadcastName, BroadcastStatus.RUNNING, BroadcastLastModified, BroadcastType.IVR, ivrBroadcastConfig);

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
            var voiceBroadcastConfig = new VoiceBroadcastConfig(ConfigId, ConfigCreated,
                ConfigFromNumber, localTimeZoneRestriction, broadcastConfigRestryConfig,
                AnsweringMachineConfig.AM_AND_LIVE, VoiceConfigItem, VoiceConfigLiveSoundTextVoice, VoiceConfigItem1,
                VoiceConfigMachineSoundTextVoice, VoiceConfigItem2, VoiceConfigTransferSoundTextVoice, VoiceConfigTransferDigit,
                VoiceConfigTransferNumber, VoiceConfigItem3, VoiceConfigDncSoundTextVoice, VoiceConfigDncDigit,
                VoiceConfigMaxActiveTransfers);
            CreateExpectedBroadcast(5, BroadcastName, BroadcastStatus.RUNNING, BroadcastLastModified, BroadcastType.VOICE, voiceBroadcastConfig);

        }

        private void CreateExpectedBroadcast(long broadcastId, string broadcastName, BroadcastStatus broadcastStatus, DateTime broadcastLastModified, BroadcastType broadcastType, BroadcastConfig broadcastCongif)
        {
            var expectedBroadcast = new Broadcast(broadcastId, broadcastName, broadcastStatus, broadcastLastModified,
                broadcastType, broadcastCongif);
            BroadcastServiceMock
                .Stub(b => b.GetBroadcast(Arg<IdRequest>.Matches(x => x.Id == broadcastId)))
                .Return(expectedBroadcast);
        }
    }
}
