using System;
using System.IO;
using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Rest.Data;
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
            CfResult[] result = { CfResult.Received };
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
            
            var resource = new Resource { Resources = null };
            GetValue(10, resource);
        }

        private void CreateExpectedBroadcast(long broadcastId)
        {
            var lastModified = ExpectedBroadcast.LastModified == null ? DateTime.Now : ExpectedBroadcast.LastModified.Value;
            var type = ExpectedBroadcast.Type == null ? CfBroadcastType.Text : ExpectedBroadcast.Type.Value;

            var expectedBroadcast = new Broadcast(broadcastId, ExpectedBroadcast.Name,
                EnumeratedMapper.ToSoapEnumerated<BroadcastStatus>(ExpectedBroadcast.Status.ToString()), lastModified,
                EnumeratedMapper.ToSoapEnumerated<BroadcastType>(type.ToString()),
                BroadcastConfigMapper.ToBroadcastConfig(ExpectedBroadcast.Item, type));

            var resource = new Resource {Resources = expectedBroadcast};
            GetValue(broadcastId, resource);
        }

        private void GetValue(long broadcastId, Resource resource)
        {
            var serializer = new XmlSerializer(typeof (Resource));
            TextWriter writer = new StringWriter();
            serializer.Serialize(writer, resource);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/{0}", broadcastId)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Get),
                    Arg<object>.Is.Null))
                .Return(writer.ToString());
        }
    }
}
