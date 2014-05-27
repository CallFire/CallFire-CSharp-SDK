using System;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Rest.Data;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    class GetBroadcastStatsRestClientTest : GetBroadcastStatsClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestBroadcastClient(HttpClientMock);

            BroadcastId = 1;
            GetBroadcastStats = new CfGetBroadcastStats(BroadcastId, DateTime.Now, DateTime.Now);
            ExpectedUsageStats = new BroadcastStatsUsageStats(5, 5, 2, 10, 2);

            var resultStat = new BroadcastStatsResultStat[1];
            ExpectedResultStat = new BroadcastStatsResultStat("result", 2, 3);
            resultStat[0] = ExpectedResultStat;

            ExpectedActionsStatistics = new BroadcastStatsActionStatistics(2, 0, 10);

            var expectedBroadcastStats = new BroadcastStats(ExpectedUsageStats, resultStat, ExpectedActionsStatistics);

            var resource = new Resource { Resources = expectedBroadcastStats };
            var serializer = new XmlSerializer(typeof(Resource));
            TextWriter writer = new StringWriter();
            serializer.Serialize(writer, resource);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/{0}/stats?IntervalBegin={1}&IntervalEnd={2}", BroadcastId, GetBroadcastStats.IntervalBegin.ToString("MM/dd/yyyy HH:mm:ss"), GetBroadcastStats.IntervalEnd.ToString("MM/dd/yyyy HH:mm:ss"))),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Get),
                    Arg<string>.Is.Anything))
                .Return(writer.ToString());
        }
    }
}
