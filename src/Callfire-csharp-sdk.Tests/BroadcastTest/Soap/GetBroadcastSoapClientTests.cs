using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class GetBroadcastSoapClientTests : GetBroadcastClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);
            ExpectedBroadcast = new CfBroadcast(1, "broadcast", CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Voice, null);
            
            CreateExpectedBroadcast(1);
            
            LocalTimeZoneRestriction = new CfLocalTimeZoneRestriction(DateTime.Now, DateTime.Now);
            CfResult[] result = { CfResult.Received };
            CfRetryPhoneType[] phoneTypes = { CfRetryPhoneType.First_Number };
            BroadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, result, phoneTypes);
            ExpectedTextBroadcastConfig = new CfTextBroadcastConfig(1, DateTime.Now, "fromNumber", null, BroadcastConfigRestryConfig, "Message", CfBigMessageStrategy.SendMultiple);
            ExpectedBroadcast.Type = CfBroadcastType.Text; 
            ExpectedBroadcast.Item = ExpectedTextBroadcastConfig;
            
            CreateExpectedBroadcast(2);
            
            ExpectedTextBroadcastConfig.LocalTimeZoneRestriction = LocalTimeZoneRestriction;
            ExpectedTextBroadcastConfig.RetryConfig = null;
            ExpectedBroadcast.Type = CfBroadcastType.Text; 
            ExpectedBroadcast.Item = ExpectedTextBroadcastConfig;

            CreateExpectedBroadcast(3);

            ExpectedIvrBroadcastConfig = new CfIvrBroadcastConfig(1, DateTime.Now, "fromNumber",
                LocalTimeZoneRestriction, BroadcastConfigRestryConfig, "dialplanXml");
            
            ExpectedBroadcast.Type = CfBroadcastType.Ivr;
            ExpectedBroadcast.Item = ExpectedIvrBroadcastConfig;
            CreateExpectedBroadcast(4);
            
            ExpectedVoiceBroadcastConfig = new CfVoiceBroadcastConfig(1, DateTime.Now, "fromNumber",
                LocalTimeZoneRestriction, BroadcastConfigRestryConfig, CfAnsweringMachineConfig.AmAndLive, "item",
                "liveSoundTextVoice", "item1", "machineSoundTextVoice", "item2", "tranferSoudnTextVoice", "1", "123456",
                "item3", "DncSoundTextVoice", "1", 5);

            ExpectedBroadcast.Type = CfBroadcastType.Voice;
            ExpectedBroadcast.Item = ExpectedVoiceBroadcastConfig;

            CreateExpectedBroadcast(5);
        }

        private void CreateExpectedBroadcast(long broadcastId)
        {
            var expectedBroadcast = new Broadcast(broadcastId, ExpectedBroadcast.Name,
                BroadcastStatusMapper.ToSoapBroadcastStatus(ExpectedBroadcast.Status), ExpectedBroadcast.LastModified,
                BroadcastTypeMapper.ToSoapBroadcastType(ExpectedBroadcast.Type),
                BroadcastConfigMapper.ToBroadcastConfig(ExpectedBroadcast.Item, ExpectedBroadcast.Type));
            BroadcastServiceMock
                .Stub(b => b.GetBroadcast(Arg<IdRequest>.Matches(x => x.Id == broadcastId)))
                .Return(expectedBroadcast);
        }
    }
}
