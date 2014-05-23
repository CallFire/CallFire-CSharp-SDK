using System;
using System.IO;
using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class GetBroadcastScheduleRestClientTest : GetBroadcastScheduleClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            BroadcastScheduleId = 1;
            CfDaysOfWeek[] daysOfWeek = { CfDaysOfWeek.Monday };
            BroadcastSchedule = new CfBroadcastSchedule(BroadcastScheduleId, DateTime.Now, DateTime.Now, "timeZone", DateTime.Now, DateTime.Now, daysOfWeek);
            
            var broadcastSchedule = BroadcastScheduleMapper.ToSoapBroadcastSchedule(BroadcastSchedule);

            var resource = new Resource { Resources = broadcastSchedule };
            var serializer = new XmlSerializer(typeof(Resource));
            TextWriter writer = new StringWriter();
            serializer.Serialize(writer, resource);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/schedule/{0}", BroadcastScheduleId)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Get),
                    Arg<object>.Is.Null))
                .Return(writer.ToString());
        }
    }
}
