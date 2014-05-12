using System;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class GetBroadcastClientTests
    {
        protected IBroadcastClient Client;
        
        protected long BroadcastId;
        protected string BroadcastName;
        protected DateTime BroadcastLastModified;
        
        protected long ConfigId;
        protected DateTime ConfigCreated;
        protected string ConfigFromNumber;
        protected DateTime ConfigBeginTime;
        protected DateTime ConfigEndTime;
        protected int ConfigMaxAttempts;
        protected int ConfigMinutesBetweenAttempts;
        protected string ConfigRetryResults;
        protected string ConfigRetryPhoneTypes;
        
        protected string TextConfigMessage;
        
        protected string IvrConfigDialplanXml;

        protected object VoiceConfigItem;
        protected string VoiceConfigLiveSoundTextVoice;
        protected object VoiceConfigItem1;
        protected string VoiceConfigMachineSoundTextVoice;
        protected object VoiceConfigItem2;
        protected string VoiceConfigTransferSoundTextVoice;
        protected string VoiceConfigTransferDigit;
        protected string VoiceConfigTransferNumber;
        protected object VoiceConfigItem3;
        protected string VoiceConfigDncSoundTextVoice;
        protected string VoiceConfigDncDigit;
        protected int VoiceConfigMaxActiveTransfers;

        [Test]
        public void Test_GetBroadcastThatDoesNotExist()
        {
            BroadcastId = 10;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNull(broadcast);
        }
        
        [Test]
        public void Test_GetBroadcast_with_null_BroadcastConfig()
        {
            BroadcastId = 1;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNotNull(broadcast);
            Assert.AreEqual(BroadcastId, broadcast.Id);
            Assert.AreEqual(BroadcastName, broadcast.Name);
            Assert.AreEqual(CfBroadcastStatus.Running, broadcast.Status);
            Assert.AreEqual(BroadcastLastModified, broadcast.LastModified);
            Assert.AreEqual(CfBroadcastType.Text, broadcast.Type);
            Assert.IsNull(broadcast.Item);
        }

        [Test]
        public void Test_GetBroadcast_of_type_BroadcastText()
        {
            BroadcastId = 2;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNotNull(broadcast);
            var textBroadcastConfig = broadcast.Item as CfTextBroadcastConfig;

            Assert.IsNotNull(textBroadcastConfig);
            Assert.AreEqual(ConfigId, textBroadcastConfig.Id);
            Assert.AreEqual(ConfigCreated, textBroadcastConfig.Created);
            Assert.AreEqual(ConfigFromNumber, textBroadcastConfig.FromNumber);
            Assert.AreEqual(TextConfigMessage, textBroadcastConfig.Message);
            Assert.AreEqual(CfBigMessageStrategy.SendMultiple, textBroadcastConfig.BigMessageStrategy);
        }

        [Test]
        public void Test_GetBroadcast_of_type_BroadcastIvr()
        {
            BroadcastId = 4;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNotNull(broadcast);
            var ivrBroadcastConfig = broadcast.Item as CfIvrBroadcastConfig;

            Assert.IsNotNull(ivrBroadcastConfig);
            Assert.AreEqual(ConfigId, ivrBroadcastConfig.Id);
            Assert.AreEqual(ConfigCreated, ivrBroadcastConfig.Created);
            Assert.AreEqual(ConfigFromNumber, ivrBroadcastConfig.FromNumber);
            Assert.AreEqual(IvrConfigDialplanXml, ivrBroadcastConfig.DialplanXml);
        }

        [Test]
        public void Test_GetBroadcast_of_type_BroadcastVoice()
        {
            BroadcastId = 5;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNotNull(broadcast);
            var voiceBroadcastConfig = broadcast.Item as CfVoiceBroadcastConfig;

            Assert.IsNotNull(voiceBroadcastConfig);
            Assert.AreEqual(ConfigId, voiceBroadcastConfig.Id);
            Assert.AreEqual(ConfigCreated, voiceBroadcastConfig.Created);
            Assert.AreEqual(ConfigFromNumber, voiceBroadcastConfig.FromNumber);
            Assert.AreEqual(VoiceConfigItem, voiceBroadcastConfig.Item);
            Assert.AreEqual(VoiceConfigLiveSoundTextVoice, voiceBroadcastConfig.LiveSoundTextVoice);
            Assert.AreEqual(VoiceConfigItem1, voiceBroadcastConfig.Item1);
            Assert.AreEqual(VoiceConfigMachineSoundTextVoice, voiceBroadcastConfig.MachineSoundTextVoice);
            Assert.AreEqual(VoiceConfigItem2, voiceBroadcastConfig.Item2);
            Assert.AreEqual(VoiceConfigTransferSoundTextVoice, voiceBroadcastConfig.TransferSoundTextVoice);
            Assert.AreEqual(VoiceConfigTransferDigit, voiceBroadcastConfig.TransferDigit);
            Assert.AreEqual(VoiceConfigTransferNumber, voiceBroadcastConfig.TransferNumber);
            Assert.AreEqual(VoiceConfigItem3, voiceBroadcastConfig.Item3);
            Assert.AreEqual(VoiceConfigDncSoundTextVoice, voiceBroadcastConfig.DncSoundTextVoice);
            Assert.AreEqual(VoiceConfigDncDigit, voiceBroadcastConfig.DncDigit);
            Assert.AreEqual(VoiceConfigMaxActiveTransfers, voiceBroadcastConfig.MaxActiveTransfers);
        }

        [Test]
        public void Test_GetBroadcast_with_null_LocalTimeZoneRestriction()
        {
            BroadcastId = 2;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNotNull(broadcast);
            var textBroadcastConfig = broadcast.Item as CfTextBroadcastConfig;

            Assert.IsNotNull(textBroadcastConfig);
            var localTimeZoneRestriction = textBroadcastConfig.LocalTimeZoneRestriction;

            Assert.IsNull(localTimeZoneRestriction);
        }

        [Test]
        public void Test_GetBroadcast_GetLocalTimeZoneRestriction()
        {
            BroadcastId = 3;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNotNull(broadcast);
            var textBroadcastConfig = broadcast.Item as CfTextBroadcastConfig; 
            
            Assert.IsNotNull(textBroadcastConfig);
            var localTimeZoneRestriction = textBroadcastConfig.LocalTimeZoneRestriction;

            Assert.IsNotNull(localTimeZoneRestriction);
            Assert.AreEqual(ConfigBeginTime, localTimeZoneRestriction.BeginTime);
            Assert.AreEqual(ConfigEndTime, localTimeZoneRestriction.EndTime);
        }

        [Test]
        public void Test_GetBroadcast_with_null_RestryConfig()
        {
            BroadcastId = 3;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNotNull(broadcast);
            var textBroadcastConfig = broadcast.Item as CfTextBroadcastConfig;

            Assert.IsNotNull(textBroadcastConfig);
            var retryConfig = textBroadcastConfig.RetryConfig;

            Assert.IsNull(retryConfig);
        }

        [Test]
        public void Test_GetBroadcast_GetRestryConfig()
        {
            BroadcastId = 2;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNotNull(broadcast);
            var textBroadcastConfig = broadcast.Item as CfTextBroadcastConfig;

            Assert.IsNotNull(textBroadcastConfig);
            var retryConfig = textBroadcastConfig.RetryConfig;

            Assert.IsNotNull(retryConfig);
            Assert.AreEqual(ConfigMaxAttempts, retryConfig.MaxAttempts);
            Assert.AreEqual(ConfigMinutesBetweenAttempts, retryConfig.MinutesBetweenAttempts);
            Assert.AreEqual(ConfigRetryResults, retryConfig.RetryResults);
            Assert.AreEqual(ConfigRetryPhoneTypes, retryConfig.RetryPhoneTypes);
        }
    }
}
