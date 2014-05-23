using System;
using System.IO;
using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class QueryBroadcastSchedulerRestClientTest : QueryBroadcastScheduleClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            BroadcastId = 1;
            QueryBroadcastSchedule = new CfQueryBroadcastData(100, 1, BroadcastId);

            CfDaysOfWeek[] daysOfWeek = { CfDaysOfWeek.Monday };
            BroadcastSchedule = new CfBroadcastSchedule(1, DateTime.Now, DateTime.Now, "timeZone", DateTime.Now, DateTime.Now, daysOfWeek);
            var broadcastSchedule = new CfBroadcastSchedule[1];
            broadcastSchedule[0] = BroadcastSchedule;
            BroadcastScheduleQueryResult = new CfBroadcastScheduleQueryResult(1, broadcastSchedule);

            var broadcastScheduleQueryResult = BroadcastScheduleQueryResultMapper.ToSoapBroadcastScheduleQueryResult(BroadcastScheduleQueryResult);

            GenerateMock(broadcastScheduleQueryResult);

            BroadcastId = 2;
            BroadcastScheduleQueryResult.BroadcastSchedule = null;
            broadcastScheduleQueryResult = BroadcastScheduleQueryResultMapper.ToSoapBroadcastScheduleQueryResult(BroadcastScheduleQueryResult);

            GenerateMock(broadcastScheduleQueryResult);
        }

        private void GenerateMock(BroadcastScheduleQueryResult broadcastScheduleQueryResult)
        {
            var resource = new ResourceList();
            var array = new BroadcastSchedule[1];
            array[0] = broadcastScheduleQueryResult.BroadcastSchedule[0];
            resource.Resource = array;
            resource.TotalResults = 1;

            var serializer = new XmlSerializer(typeof(ResourceList));
            TextWriter writer = new StringWriter();
            serializer.Serialize(writer, resource);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/{0}/schedule?MaxResults={1}&FirstResult={2}",
                        BroadcastId, QueryBroadcastSchedule.MaxResults, QueryBroadcastSchedule.FirstResult)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Get),
                    Arg<object>.Is.Null))
                .Return(writer.ToString());
        }
    }
}
