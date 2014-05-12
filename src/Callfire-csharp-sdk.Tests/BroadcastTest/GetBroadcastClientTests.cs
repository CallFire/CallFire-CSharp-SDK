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
        protected CfBroadcast ExpectedBroadcast;
        
        protected CfLocalTimeZoneRestriction LocalTimeZoneRestriction;
        protected CfBroadcastConfigRetryConfig BroadcastConfigRestryConfig;

        protected CfTextBroadcastConfig ExpectedTextBroadcastConfig;
        protected CfIvrBroadcastConfig ExpectedIvrBroadcastConfig;
        protected CfVoiceBroadcastConfig ExpectedVoiceBroadcastConfig;
       

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
            Assert.AreEqual(ExpectedBroadcast.Name, broadcast.Name);
            Assert.AreEqual(ExpectedBroadcast.Status, broadcast.Status);
            Assert.AreEqual(ExpectedBroadcast.LastModified, broadcast.LastModified);
            Assert.AreEqual(ExpectedBroadcast.Type, broadcast.Type);
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
            Assert.AreEqual(ExpectedTextBroadcastConfig.Id, textBroadcastConfig.Id);
            Assert.AreEqual(ExpectedTextBroadcastConfig.Created, textBroadcastConfig.Created);
            Assert.AreEqual(ExpectedTextBroadcastConfig.FromNumber, textBroadcastConfig.FromNumber);
            Assert.AreEqual(ExpectedTextBroadcastConfig.Message, textBroadcastConfig.Message);
            Assert.AreEqual(ExpectedTextBroadcastConfig.BigMessageStrategy, textBroadcastConfig.BigMessageStrategy);
        }
        
        [Test]
        public void Test_GetBroadcast_of_type_BroadcastIvr()
        {
            BroadcastId = 4;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNotNull(broadcast);
            var ivrBroadcastConfig = broadcast.Item as CfIvrBroadcastConfig;

            Assert.IsNotNull(ivrBroadcastConfig);
            Assert.AreEqual(ExpectedIvrBroadcastConfig.Id, ivrBroadcastConfig.Id);
            Assert.AreEqual(ExpectedIvrBroadcastConfig.Created, ivrBroadcastConfig.Created);
            Assert.AreEqual(ExpectedIvrBroadcastConfig.FromNumber, ivrBroadcastConfig.FromNumber);
            Assert.AreEqual(ExpectedIvrBroadcastConfig.DialplanXml, ivrBroadcastConfig.DialplanXml);
        }

        [Test]
        public void Test_GetBroadcast_of_type_BroadcastVoice()
        {
            BroadcastId = 5;
            var broadcast = Client.GetBroadcast(BroadcastId);

            Assert.IsNotNull(broadcast);
            var voiceBroadcastConfig = broadcast.Item as CfVoiceBroadcastConfig;

            Assert.IsNotNull(voiceBroadcastConfig);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.Id, voiceBroadcastConfig.Id);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.Created, voiceBroadcastConfig.Created);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.FromNumber, voiceBroadcastConfig.FromNumber);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.Item, voiceBroadcastConfig.Item);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.LiveSoundTextVoice, voiceBroadcastConfig.LiveSoundTextVoice);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.Item1, voiceBroadcastConfig.Item1);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.MachineSoundTextVoice, voiceBroadcastConfig.MachineSoundTextVoice);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.Item2, voiceBroadcastConfig.Item2);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.TransferSoundTextVoice, voiceBroadcastConfig.TransferSoundTextVoice);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.TransferDigit, voiceBroadcastConfig.TransferDigit);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.TransferNumber, voiceBroadcastConfig.TransferNumber);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.Item3, voiceBroadcastConfig.Item3);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.DncSoundTextVoice, voiceBroadcastConfig.DncSoundTextVoice);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.DncDigit, voiceBroadcastConfig.DncDigit);
            Assert.AreEqual(ExpectedVoiceBroadcastConfig.MaxActiveTransfers, voiceBroadcastConfig.MaxActiveTransfers);
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
            Assert.AreEqual(LocalTimeZoneRestriction.BeginTime, localTimeZoneRestriction.BeginTime);
            Assert.AreEqual(LocalTimeZoneRestriction.EndTime, localTimeZoneRestriction.EndTime);
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
            Assert.AreEqual(BroadcastConfigRestryConfig.MaxAttempts, retryConfig.MaxAttempts);
            Assert.AreEqual(BroadcastConfigRestryConfig.MinutesBetweenAttempts, retryConfig.MinutesBetweenAttempts);
            Assert.AreEqual(BroadcastConfigRestryConfig.RetryResults, retryConfig.RetryResults);
            Assert.AreEqual(BroadcastConfigRestryConfig.RetryPhoneTypes, retryConfig.RetryPhoneTypes);
        }
    }
}
