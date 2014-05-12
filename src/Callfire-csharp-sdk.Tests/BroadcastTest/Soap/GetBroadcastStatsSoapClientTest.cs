using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    internal class GetBroadcastStatsSoapClientTest : GetBroadcastStatsClientTest
    {
        protected IBroadcastServicePortTypeClient BroadcastServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            BroadcastServiceMock = MockRepository.GenerateStub<IBroadcastServicePortTypeClient>();
            Client = new SoapBroadcastClient(BroadcastServiceMock);
            BroadcastId = 1;

            ExpectedUsageStats = new BroadcastStatsUsageStats(5, 5, 2, 10, 2);

            var resultStat = new BroadcastStatsResultStat[1];
            ExpectedResultStat = new BroadcastStatsResultStat("result", 2, 3);
            resultStat[0] = ExpectedResultStat;

            ExpectedActionsStatistics = new BroadcastStatsActionStatistics(2, 0, 10);

            var expectedBroadcastStats = new BroadcastStats(ExpectedUsageStats, resultStat, ExpectedActionsStatistics);
            BroadcastServiceMock
                .Stub(b => b.GetBroadcastStats(Arg<GetBroadcastStats>.Matches(x => x.Id == BroadcastId)))
                .Return(expectedBroadcastStats);
        }
    }
}
