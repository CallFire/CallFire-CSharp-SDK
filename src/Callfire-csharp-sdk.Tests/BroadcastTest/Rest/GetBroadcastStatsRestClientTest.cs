using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
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

            ExpectedUsageStats = new BroadcastStatsUsageStats(5, 5, 2, 10, 2);

            var resultStat = new BroadcastStatsResultStat[1];
            ExpectedResultStat = new BroadcastStatsResultStat("result", 2, 3);
            resultStat[0] = ExpectedResultStat;

            ExpectedActionsStatistics = new BroadcastStatsActionStatistics(2, 0, 10);

            var expectedBroadcastStats = new BroadcastStats(ExpectedUsageStats, resultStat, ExpectedActionsStatistics);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/broadcast/{0}/stats", BroadcastId)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Get),
                    Arg<string>.Is.Anything))
                .Return("");//expectedBroadcastStats);
        }
    }
}
