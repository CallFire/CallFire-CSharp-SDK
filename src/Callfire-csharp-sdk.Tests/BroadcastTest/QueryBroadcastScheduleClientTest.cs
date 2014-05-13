using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class QueryBroadcastScheduleClientTest
    {
        protected IBroadcastClient Client;

        protected CfQueryBroadcastSchedules QueryBroadcastSchedule;
        protected CfBroadcastScheduleQueryResult BroadcastScheduleQueryResult;
        protected CfBroadcastSchedule BroadcastSchedule;

        protected long BroadcastId;

        [Test]
        public void Test_QueryBroadcastSchedule()
        {
            BroadcastId = 1;
            QueryBroadcastSchedule = new CfQueryBroadcastSchedules(100, 1, BroadcastId);

            var cfBroadcastScheduleQueryResult = Client.QueryBroadcastSchedule(QueryBroadcastSchedule);
            Assert.IsNotNull(cfBroadcastScheduleQueryResult);
        }

        [Test]
        public void Test_QueryBroadcastSchedule_Properties()
        {
            BroadcastId = 1;
            QueryBroadcastSchedule = new CfQueryBroadcastSchedules(100, 1, BroadcastId);

            var cfBroadcastScheduleQueryResult = Client.QueryBroadcastSchedule(QueryBroadcastSchedule);
            Assert.IsNotNull(cfBroadcastScheduleQueryResult);

            Assert.AreEqual(BroadcastScheduleQueryResult.TotalResults, cfBroadcastScheduleQueryResult.TotalResults);
            Assert.IsNotNull(cfBroadcastScheduleQueryResult.BroadcastSchedule);
            
            var broadcastSchedule = cfBroadcastScheduleQueryResult.BroadcastSchedule[0];
            Assert.AreEqual(BroadcastSchedule.Id, broadcastSchedule.Id);
            Assert.AreEqual(BroadcastSchedule.StartTimeOfDay, broadcastSchedule.StartTimeOfDay);
            Assert.AreEqual(BroadcastSchedule.StopTimeOfDay, broadcastSchedule.StopTimeOfDay);
            Assert.AreEqual(BroadcastSchedule.TimeZone, broadcastSchedule.TimeZone);
            Assert.AreEqual(BroadcastSchedule.BeginDate, broadcastSchedule.BeginDate);
            Assert.AreEqual(BroadcastSchedule.EndDate, broadcastSchedule.EndDate);
            Assert.AreEqual(BroadcastSchedule.DaysOfWeek, broadcastSchedule.DaysOfWeek);
        }

        [Test]
        public void Test_QueryBroadcastSchedule_Whitout_BroadcastSchedule()
        {
            BroadcastId = 2;
            QueryBroadcastSchedule = new CfQueryBroadcastSchedules(100, 1, BroadcastId);

            var cfBroadcastScheduleQueryResult = Client.QueryBroadcastSchedule(QueryBroadcastSchedule);
            Assert.IsNotNull(cfBroadcastScheduleQueryResult);
            Assert.IsNull(cfBroadcastScheduleQueryResult.BroadcastSchedule);
        }
    }
}
