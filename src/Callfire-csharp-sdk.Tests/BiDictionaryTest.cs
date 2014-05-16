using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests
{
    [TestFixture]
    public class BiDictionaryTest
    {
        [Test]
        public void Test_BroadcastTypeMapper()
        {
            Assert.AreEqual(CfBroadcastType.Text, BroadcastTypeMapper.FromSoapBroadcastType(BroadcastType.TEXT));
            Assert.AreEqual(BroadcastType.TEXT, BroadcastTypeMapper.ToSoapBroadcastType(CfBroadcastType.Text));

            Assert.AreEqual(CfBroadcastType.Ivr, BroadcastTypeMapper.FromSoapBroadcastType(BroadcastType.IVR));
            Assert.AreEqual(BroadcastType.IVR, BroadcastTypeMapper.ToSoapBroadcastType(CfBroadcastType.Ivr));

            Assert.AreEqual(CfBroadcastType.Voice, BroadcastTypeMapper.FromSoapBroadcastType(BroadcastType.VOICE));
            Assert.AreEqual(BroadcastType.VOICE, BroadcastTypeMapper.ToSoapBroadcastType(CfBroadcastType.Voice));
        }

        [Test]
        public void Test_AnsweringMachineConfigMapper()
        {
            Assert.AreEqual(CfAnsweringMachineConfig.AmAndLive, AnsweringMachineConfigMapper.FromSoapAnsweringMachineConfig(AnsweringMachineConfig.AM_AND_LIVE));
            Assert.AreEqual(AnsweringMachineConfig.AM_AND_LIVE, AnsweringMachineConfigMapper.ToSoapAnsweringMachineConfig(CfAnsweringMachineConfig.AmAndLive));

            Assert.AreEqual(CfAnsweringMachineConfig.AmOnly, AnsweringMachineConfigMapper.FromSoapAnsweringMachineConfig(AnsweringMachineConfig.AM_ONLY));
            Assert.AreEqual(AnsweringMachineConfig.AM_ONLY, AnsweringMachineConfigMapper.ToSoapAnsweringMachineConfig(CfAnsweringMachineConfig.AmOnly));

            Assert.AreEqual(CfAnsweringMachineConfig.LiveImmediate, AnsweringMachineConfigMapper.FromSoapAnsweringMachineConfig(AnsweringMachineConfig.LIVE_IMMEDIATE));
            Assert.AreEqual(AnsweringMachineConfig.LIVE_IMMEDIATE, AnsweringMachineConfigMapper.ToSoapAnsweringMachineConfig(CfAnsweringMachineConfig.LiveImmediate));

            Assert.AreEqual(CfAnsweringMachineConfig.LiveWithAmd, AnsweringMachineConfigMapper.FromSoapAnsweringMachineConfig(AnsweringMachineConfig.LIVE_WITH_AMD));
            Assert.AreEqual(AnsweringMachineConfig.LIVE_WITH_AMD, AnsweringMachineConfigMapper.ToSoapAnsweringMachineConfig(CfAnsweringMachineConfig.LiveWithAmd));
        }

        [Test]
        public void Test_BatchStatusMapper()
        {
            Assert.AreEqual(CfBatchStatus.Active, BatchStatusMapper.FromSoapBatchStatus(BatchStatus.ACTIVE));
            Assert.AreEqual(BatchStatus.ACTIVE, BatchStatusMapper.ToSoapBatchStatus(CfBatchStatus.Active));

            Assert.AreEqual(CfBatchStatus.Errors, BatchStatusMapper.FromSoapBatchStatus(BatchStatus.ERRORS));
            Assert.AreEqual(BatchStatus.ERRORS, BatchStatusMapper.ToSoapBatchStatus(CfBatchStatus.Errors));

            Assert.AreEqual(CfBatchStatus.New, BatchStatusMapper.FromSoapBatchStatus(BatchStatus.NEW));
            Assert.AreEqual(BatchStatus.NEW, BatchStatusMapper.ToSoapBatchStatus(CfBatchStatus.New));

            Assert.AreEqual(CfBatchStatus.SourceError, BatchStatusMapper.FromSoapBatchStatus(BatchStatus.SOURCE_ERROR));
            Assert.AreEqual(BatchStatus.SOURCE_ERROR, BatchStatusMapper.ToSoapBatchStatus(CfBatchStatus.SourceError));

            Assert.AreEqual(CfBatchStatus.Validating, BatchStatusMapper.FromSoapBatchStatus(BatchStatus.VALIDATING));
            Assert.AreEqual(BatchStatus.VALIDATING, BatchStatusMapper.ToSoapBatchStatus(CfBatchStatus.Validating));
        }

        [Test]
        public void Test_BigMessageStrategyMapper()
        {
            Assert.AreEqual(CfBigMessageStrategy.DoNotSend, BigMessageStrategyMapper.FromBigMessageStrategy(BigMessageStrategy.DO_NOT_SEND));
            Assert.AreEqual(BigMessageStrategy.DO_NOT_SEND, BigMessageStrategyMapper.ToBigMessageStrategy(CfBigMessageStrategy.DoNotSend));

            Assert.AreEqual(CfBigMessageStrategy.SendMultiple, BigMessageStrategyMapper.FromBigMessageStrategy(BigMessageStrategy.SEND_MULTIPLE));
            Assert.AreEqual(BigMessageStrategy.SEND_MULTIPLE, BigMessageStrategyMapper.ToBigMessageStrategy(CfBigMessageStrategy.SendMultiple));

            Assert.AreEqual(CfBigMessageStrategy.Trim, BigMessageStrategyMapper.FromBigMessageStrategy(BigMessageStrategy.TRIM));
            Assert.AreEqual(BigMessageStrategy.TRIM, BigMessageStrategyMapper.ToBigMessageStrategy(CfBigMessageStrategy.Trim));
        }

        [Test]
        public void Test_BroadcastCommandMapper()
        {
            Assert.AreEqual(CfBroadcastCommand.Archive, BroadcastCommandMapper.FromSoapBroadcastCommand(BroadcastCommand.ARCHIVE));
            Assert.AreEqual(BroadcastCommand.ARCHIVE, BroadcastCommandMapper.ToSoapContactBatch(CfBroadcastCommand.Archive));

            Assert.AreEqual(CfBroadcastCommand.Start, BroadcastCommandMapper.FromSoapBroadcastCommand(BroadcastCommand.START));
            Assert.AreEqual(BroadcastCommand.START, BroadcastCommandMapper.ToSoapContactBatch(CfBroadcastCommand.Start));

            Assert.AreEqual(CfBroadcastCommand.Stop, BroadcastCommandMapper.FromSoapBroadcastCommand(BroadcastCommand.STOP));
            Assert.AreEqual(BroadcastCommand.STOP, BroadcastCommandMapper.ToSoapContactBatch(CfBroadcastCommand.Stop));
        }

        [Test]
        public void Test_BroadcastStatusMapper()
        {
            Assert.AreEqual(CfBroadcastStatus.Archived, BroadcastStatusMapper.FromSoapBroadcastStatus(BroadcastStatus.ARCHIVED));
            Assert.AreEqual(BroadcastStatus.ARCHIVED, BroadcastStatusMapper.ToSoapBroadcastStatus(CfBroadcastStatus.Archived));
        
            Assert.AreEqual(CfBroadcastStatus.Finished, BroadcastStatusMapper.FromSoapBroadcastStatus(BroadcastStatus.FINISHED));
            Assert.AreEqual(BroadcastStatus.FINISHED, BroadcastStatusMapper.ToSoapBroadcastStatus(CfBroadcastStatus.Finished));
            
            Assert.AreEqual(CfBroadcastStatus.Running, BroadcastStatusMapper.FromSoapBroadcastStatus(BroadcastStatus.RUNNING));
            Assert.AreEqual(BroadcastStatus.RUNNING, BroadcastStatusMapper.ToSoapBroadcastStatus(CfBroadcastStatus.Running));
            
            Assert.AreEqual(CfBroadcastStatus.StartPending, BroadcastStatusMapper.FromSoapBroadcastStatus(BroadcastStatus.START_PENDING));
            Assert.AreEqual(BroadcastStatus.START_PENDING, BroadcastStatusMapper.ToSoapBroadcastStatus(CfBroadcastStatus.StartPending));
            
            Assert.AreEqual(CfBroadcastStatus.Stopped, BroadcastStatusMapper.FromSoapBroadcastStatus(BroadcastStatus.STOPPED));
            Assert.AreEqual(BroadcastStatus.STOPPED, BroadcastStatusMapper.ToSoapBroadcastStatus(CfBroadcastStatus.Stopped));
        }

        [Test]
        public void Test_NotificationFormatMapper()
        {
            Assert.AreEqual(CfNotificationFormat.Email, NotificationFormatMapper.FromSoapNotificationFormat(NotificationFormat.EMAIL));
            Assert.AreEqual(NotificationFormat.EMAIL, NotificationFormatMapper.ToSoapNotificationFormat(CfNotificationFormat.Email));

            Assert.AreEqual(CfNotificationFormat.Json, NotificationFormatMapper.FromSoapNotificationFormat(NotificationFormat.JSON));
            Assert.AreEqual(NotificationFormat.JSON, NotificationFormatMapper.ToSoapNotificationFormat(CfNotificationFormat.Json));

            Assert.AreEqual(CfNotificationFormat.Soap, NotificationFormatMapper.FromSoapNotificationFormat(NotificationFormat.SOAP));
            Assert.AreEqual(NotificationFormat.SOAP, NotificationFormatMapper.ToSoapNotificationFormat(CfNotificationFormat.Soap));

            Assert.AreEqual(CfNotificationFormat.Xml, NotificationFormatMapper.FromSoapNotificationFormat(NotificationFormat.XML));
            Assert.AreEqual(NotificationFormat.XML, NotificationFormatMapper.ToSoapNotificationFormat(CfNotificationFormat.Xml));
        }

        [Test]
        public void Test_SubscriptionTriggerEventMapper()
        {
            Assert.AreEqual(CfSubscriptionTriggerEvent.CampaignFinished, SubscriptionTriggerEventMapper.FromSoapSubscriptionTriggerEvent(SubscriptionTriggerEvent.CAMPAIGN_FINISHED));
            Assert.AreEqual(SubscriptionTriggerEvent.CAMPAIGN_FINISHED, SubscriptionTriggerEventMapper.ToSoapSubscriptionTriggerEvent(CfSubscriptionTriggerEvent.CampaignFinished));
           
            Assert.AreEqual(CfSubscriptionTriggerEvent.CampaignStarted, SubscriptionTriggerEventMapper.FromSoapSubscriptionTriggerEvent(SubscriptionTriggerEvent.CAMPAIGN_STARTED));
            Assert.AreEqual(SubscriptionTriggerEvent.CAMPAIGN_STARTED, SubscriptionTriggerEventMapper.ToSoapSubscriptionTriggerEvent(CfSubscriptionTriggerEvent.CampaignStarted));
            
            Assert.AreEqual(CfSubscriptionTriggerEvent.CampaignStopped, SubscriptionTriggerEventMapper.FromSoapSubscriptionTriggerEvent(SubscriptionTriggerEvent.CAMPAIGN_STOPPED));
            Assert.AreEqual(SubscriptionTriggerEvent.CAMPAIGN_STOPPED, SubscriptionTriggerEventMapper.ToSoapSubscriptionTriggerEvent(CfSubscriptionTriggerEvent.CampaignStopped));
            
            Assert.AreEqual(CfSubscriptionTriggerEvent.InboundCallFinished, SubscriptionTriggerEventMapper.FromSoapSubscriptionTriggerEvent(SubscriptionTriggerEvent.INBOUND_CALL_FINISHED));
            Assert.AreEqual(SubscriptionTriggerEvent.INBOUND_CALL_FINISHED, SubscriptionTriggerEventMapper.ToSoapSubscriptionTriggerEvent(CfSubscriptionTriggerEvent.InboundCallFinished));
            
            Assert.AreEqual(CfSubscriptionTriggerEvent.InboundTextFinished, SubscriptionTriggerEventMapper.FromSoapSubscriptionTriggerEvent(SubscriptionTriggerEvent.INBOUND_TEXT_FINISHED));
            Assert.AreEqual(SubscriptionTriggerEvent.INBOUND_TEXT_FINISHED, SubscriptionTriggerEventMapper.ToSoapSubscriptionTriggerEvent(CfSubscriptionTriggerEvent.InboundTextFinished));
            
            Assert.AreEqual(CfSubscriptionTriggerEvent.OutboundCallFinished, SubscriptionTriggerEventMapper.FromSoapSubscriptionTriggerEvent(SubscriptionTriggerEvent.OUTBOUND_CALL_FINISHED));
            Assert.AreEqual(SubscriptionTriggerEvent.OUTBOUND_CALL_FINISHED, SubscriptionTriggerEventMapper.ToSoapSubscriptionTriggerEvent(CfSubscriptionTriggerEvent.OutboundCallFinished));
            
            Assert.AreEqual(CfSubscriptionTriggerEvent.OutboundTextFinished, SubscriptionTriggerEventMapper.FromSoapSubscriptionTriggerEvent(SubscriptionTriggerEvent.OUTBOUND_TEXT_FINISHED));
            Assert.AreEqual(SubscriptionTriggerEvent.OUTBOUND_TEXT_FINISHED, SubscriptionTriggerEventMapper.ToSoapSubscriptionTriggerEvent(CfSubscriptionTriggerEvent.OutboundTextFinished));
            
            Assert.AreEqual(CfSubscriptionTriggerEvent.UndefinedEvent, SubscriptionTriggerEventMapper.FromSoapSubscriptionTriggerEvent(SubscriptionTriggerEvent.UNDEFINED_EVENT));
            Assert.AreEqual(SubscriptionTriggerEvent.UNDEFINED_EVENT, SubscriptionTriggerEventMapper.ToSoapSubscriptionTriggerEvent(CfSubscriptionTriggerEvent.UndefinedEvent));
        }
    }
}
