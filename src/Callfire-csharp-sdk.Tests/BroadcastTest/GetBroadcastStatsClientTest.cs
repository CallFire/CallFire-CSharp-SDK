using CallFire_csharp_sdk.API;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class GetBroadcastStatsClientTest
    {
        protected IBroadcastClient Client;
        
        protected long BroadcastId;

        protected int Duration;
        protected int BilledDuration;
        protected float BilledAmount;
        protected int Attempts;
        protected int Actions;

        protected string Result;

        protected int Unattempted;
        protected int RetryWait;
        protected int Finished;
        
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
            Assert.AreEqual(Duration, usageStats.Duration);
            Assert.AreEqual(BilledDuration, usageStats.BilledDuration);
            Assert.AreEqual(BilledAmount, usageStats.BilledAmount);
            Assert.AreEqual(Attempts, usageStats.Attempts);
            Assert.AreEqual(Actions, usageStats.Actions);
        }

        [Test]
        public void Test_GetBroadcastStats_ActionStatistics()
        {
            var broadcastStats = Client.GetBroadcastStats(BroadcastId);
            Assert.IsNotNull(broadcastStats);

            var actionStatistics = broadcastStats.ActionStatistics;
            Assert.IsNotNull(actionStatistics);
            Assert.AreEqual(Unattempted, actionStatistics.Unattempted);
            Assert.AreEqual(RetryWait, actionStatistics.RetryWait);
            Assert.AreEqual(Finished, actionStatistics.Finished);
        }

        [Test]
        public void Test_GetBroadcastStats_ResultStat()
        {
            var broadcastStats = Client.GetBroadcastStats(BroadcastId);
            Assert.IsNotNull(broadcastStats);

            var resultStats = broadcastStats.ResultStat[0];
            Assert.IsNotNull(resultStats);
            Assert.AreEqual(Result, resultStats.Result);
            Assert.AreEqual(Attempts, resultStats.Attempts);
            Assert.AreEqual(Actions, resultStats.Actions);
        }
    }
}
