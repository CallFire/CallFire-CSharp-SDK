using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.API.Soap;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class GetBroadcastStatsClientTest
    {
        protected IBroadcastClient Client;
        
        protected long BroadcastId;

        protected BroadcastStatsUsageStats ExpectedUsageStats;
        protected BroadcastStatsActionStatistics ExpectedActionsStatistics;
        protected BroadcastStatsResultStat ExpectedResultStat;
        
        [Test]
        public void Test_GetBroadcastStats()
        {
            var broadcastStats = Client.GetBroadcastStats(BroadcastId);
            Assert.IsNotNull(broadcastStats);
        }
        
        [Test]
        public void Test_GetBroadcastStats_UsageStats()
        {
            var broadcastStats = Client.GetBroadcastStats(BroadcastId);
            Assert.IsNotNull(broadcastStats);

            var usageStats = broadcastStats.UsageStats;
            Assert.IsNotNull(usageStats);
            Assert.AreEqual(ExpectedUsageStats.Duration, usageStats.Duration);
            Assert.AreEqual(ExpectedUsageStats.BilledDuration, usageStats.BilledDuration);
            Assert.AreEqual(ExpectedUsageStats.BilledAmount, usageStats.BilledAmount);
            Assert.AreEqual(ExpectedUsageStats.Attempts, usageStats.Attempts);
            Assert.AreEqual(ExpectedUsageStats.Actions, usageStats.Actions);
        }

        [Test]
        public void Test_GetBroadcastStats_ActionStatistics()
        {
            var broadcastStats = Client.GetBroadcastStats(BroadcastId);
            Assert.IsNotNull(broadcastStats);

            var actionStatistics = broadcastStats.ActionStatistics;
            Assert.IsNotNull(actionStatistics);
            Assert.AreEqual(ExpectedActionsStatistics.Unattempted, actionStatistics.Unattempted);
            Assert.AreEqual(ExpectedActionsStatistics.RetryWait, actionStatistics.RetryWait);
            Assert.AreEqual(ExpectedActionsStatistics.Finished, actionStatistics.Finished);
        }

        [Test]
        public void Test_GetBroadcastStats_ResultStat()
        {
            var broadcastStats = Client.GetBroadcastStats(BroadcastId);
            Assert.IsNotNull(broadcastStats);

            var resultStats = broadcastStats.ResultStat[0];
            Assert.IsNotNull(resultStats);
            Assert.AreEqual(ExpectedResultStat.Result, resultStats.Result);
            Assert.AreEqual(ExpectedResultStat.Attempts, resultStats.Attempts);
            Assert.AreEqual(ExpectedResultStat.Actions, resultStats.Actions);
        }
    }
}
