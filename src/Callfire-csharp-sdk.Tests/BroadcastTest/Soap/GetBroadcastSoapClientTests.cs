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
            CfResult[] result = { CfResult.CarrierTempError };
            CfRetryPhoneType[] phoneTypes = { CfRetryPhoneType.FirstNumber };
            BroadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, result, phoneTypes);

            ExpectedVoiceBroadcastConfig = new CfVoiceBroadcastConfig(1, DateTime.Now, "fromNumber",
                null, BroadcastConfigRestryConfig, CfAnsweringMachineConfig.AmAndLive, "item",
                "liveSoundTextVoice", "item1", "machineSoundTextVoice", "item2", "tranferSoudnTextVoice", "1", "123456",
                "item3", "DncSoundTextVoice", "1", 5);
            ExpectedBroadcast.Item = ExpectedVoiceBroadcastConfig;
 
            CreateExpectedBroadcast(2);

            ExpectedVoiceBroadcastConfig.LocalTimeZoneRestriction = LocalTimeZoneRestriction;
            ExpectedVoiceBroadcastConfig.RetryConfig = null;
            ExpectedBroadcast.Item = ExpectedVoiceBroadcastConfig;

            CreateExpectedBroadcast(3);
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
