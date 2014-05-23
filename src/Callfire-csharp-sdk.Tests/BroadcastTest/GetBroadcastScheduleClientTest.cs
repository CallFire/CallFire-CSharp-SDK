using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class GetBroadcastScheduleClientTest
    {
        protected IBroadcastClient Client;

        protected long BroadcastScheduleId;
        protected CfBroadcastSchedule BroadcastSchedule;

        [Test]
        public void Test_GetBroadcastSchedule()
        {
            var broadcastSchedule = Client.GetBroadcastSchedule(BroadcastScheduleId);
            Assert.IsNotNull(broadcastSchedule);
        }

        [Test]
        public void Test_GetBroadcastSchedule_Properties()
        {
            var broadcastSchedule = Client.GetBroadcastSchedule(BroadcastScheduleId);
            Assert.IsNotNull(broadcastSchedule);

            Assert.AreEqual(BroadcastSchedule.Id, broadcastSchedule.Id);
            Assert.AreEqual(BroadcastSchedule.StartTimeOfDay, broadcastSchedule.StartTimeOfDay);
            Assert.AreEqual(BroadcastSchedule.StopTimeOfDay, broadcastSchedule.StopTimeOfDay);
            Assert.AreEqual(BroadcastSchedule.TimeZone, broadcastSchedule.TimeZone);
            Assert.AreEqual(BroadcastSchedule.BeginDate, broadcastSchedule.BeginDate);
            Assert.AreEqual(BroadcastSchedule.EndDate, broadcastSchedule.EndDate);
            Assert.AreEqual(BroadcastSchedule.DaysOfWeek[0], broadcastSchedule.DaysOfWeek[0]);
        }
    }
}
