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

            Duration = 5;
            BilledDuration = 5;
            BilledAmount = 2;
            Attempts = 10;
            Actions = 2;
            var usageStats = new BroadcastStatsUsageStats(Duration, BilledDuration, BilledAmount, Attempts, Actions);

            var resultStat = new BroadcastStatsResultStat[1];

            Unattempted = 2;
            RetryWait = 0;
            Finished = 10;
            var actionStatistics = new BroadcastStatsActionStatistics(Unattempted, RetryWait, Finished);
            
            var expectedBroadcastStats = new BroadcastStats(usageStats, resultStat, actionStatistics);
            BroadcastServiceMock
                .Stub(b => b.GetBroadcastStats(Arg<GetBroadcastStats>.Matches(x => x.Id == BroadcastId)))
                .Return(expectedBroadcastStats);
        }
    }
}
