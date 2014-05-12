using System;
using CallFire_csharp_sdk.API.Rest.BroadcastRest;
using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    class GetBroadcastStatsRestClientTest : GetBroadcastStatsClientTest
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestBroadcastClient(JsonServiceClientMock);

            BroadcastId = 1;

            Duration = 5;
            BilledDuration = 5;
            BilledAmount = 2;
            Attempts = 10;
            Actions = 2;
            var usageStats = new BroadcastStatsUsageStats(Duration, BilledDuration, BilledAmount, Attempts, Actions);

            var resultStat = new BroadcastStatsResultStat[1];
            Result = "result";
            resultStat[0] = new BroadcastStatsResultStat(Result, Attempts, Actions);

            Unattempted = 2;
            RetryWait = 0;
            Finished = 10;
            var actionStatistics = new BroadcastStatsActionStatistics(Unattempted, RetryWait, Finished);

            var expectedBroadcastStats = new BroadcastStats(usageStats, resultStat, actionStatistics);

            JsonServiceClientMock
                .Stub(j => j.Send<BroadcastStats>(Arg<string>.Is.Equal(HttpMethods.Get),
                    Arg<string>.Is.Equal(String.Format("/broadcast/{0}/stats", BroadcastId)),
                    Arg<object>.Is.Null))
                .Return(expectedBroadcastStats);
        }
    }
}
