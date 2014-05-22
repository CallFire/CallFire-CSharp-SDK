using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class GetBroadcastRestClientTests : GetBroadcastClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            ExpectedBroadcast = new CfBroadcast(1, "broadcast", CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Voice, null);
            
            CreateExpectedBroadcast(1);

            LocalTimeZoneRestriction = new CfLocalTimeZoneRestriction(DateTime.Now, DateTime.Now);
            BroadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, "retryResult", "retryPhoneTypes");
            ExpectedTextBroadcastConfig = new CfTextBroadcastConfig(1, DateTime.Now, "fromNumber", null, BroadcastConfigRestryConfig, "Message", CfBigMessageStrategy.SendMultiple);
            ExpectedBroadcast.Type = CfBroadcastType.Text;
            ExpectedBroadcast.Item = ExpectedTextBroadcastConfig;

            CreateExpectedBroadcast(2);

            ExpectedTextBroadcastConfig.LocalTimeZoneRestriction = LocalTimeZoneRestriction;
            ExpectedTextBroadcastConfig.RetryConfig = null;
            ExpectedBroadcast.Type = CfBroadcastType.Text;
            ExpectedBroadcast.Item = ExpectedTextBroadcastConfig;

            CreateExpectedBroadcast(3);

            ExpectedIvrBroadcastConfig = new CfIvrBroadcastConfig(1, DateTime.Now, "fromNumber", LocalTimeZoneRestriction, BroadcastConfigRestryConfig, "dialplanXml");
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

            var resource = string.Format("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" + 
                            "<r:Resource xmlns=\"http://api.callfire.com/data\" xmlns:r=\"http://api.callfire.com/resource\">" +
                                    "<Broadcast id=\"{0}\">" + 
                                        "<Name>{1}</Name>" + 
                                        "<Status>{2}</Status>" +
                                        "<LastModified>{3}</LastModified>" + 
                                        "<Type>{4}</Type>" +
                                    "</Broadcast>" +
                            "</r:Resource>", broadcastId, ExpectedBroadcast.Name, BroadcastStatusMapper.ToSoapBroadcastStatus(ExpectedBroadcast.Status),
                            ExpectedBroadcast.LastModified, BroadcastTypeMapper.ToSoapBroadcastType(ExpectedBroadcast.Type));

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/{0}", broadcastId)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Get), 
                    Arg<object>.Is.Null))
                .Return(resource);
        }
    }
}
