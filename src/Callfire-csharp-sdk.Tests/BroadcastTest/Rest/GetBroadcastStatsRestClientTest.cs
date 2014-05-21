using System;
using CallFire_csharp_sdk.API.Rest;
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
        protected XmlServiceClient XmlServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            XmlServiceClientMock = MockRepository.GenerateMock<XmlServiceClient>();
            Client = new RestBroadcastClient(XmlServiceClientMock);

            BroadcastId = 1;

            ExpectedUsageStats = new BroadcastStatsUsageStats(5, 5, 2, 10, 2);

            var resultStat = new BroadcastStatsResultStat[1];
            ExpectedResultStat = new BroadcastStatsResultStat("result", 2, 3);
            resultStat[0] = ExpectedResultStat;

            ExpectedActionsStatistics = new BroadcastStatsActionStatistics(2, 0, 10);

            var expectedBroadcastStats = new BroadcastStats(ExpectedUsageStats, resultStat, ExpectedActionsStatistics);
            
            XmlServiceClientMock
                .Stub(j => j.Send<BroadcastStats>(Arg<string>.Is.Equal(HttpMethods.Get),
                    Arg<string>.Is.Equal(String.Format("/broadcast/{0}/stats", BroadcastId)),
                    Arg<object>.Is.Null))
                .Return(expectedBroadcastStats);
        }
    }
}
