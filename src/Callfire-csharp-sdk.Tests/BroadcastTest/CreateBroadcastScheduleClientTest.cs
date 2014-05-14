using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class CreateBroadcastScheduleClientTest
    {
        protected IBroadcastClient Client;

        protected long BroadcastScheduleId;
        protected CfCreateBroadcastSchedule CreateBroadcastSchedule;
        protected CfBroadcastSchedule BroadcastSchedule;

        [Test]
        public void Test_CreateContactBatch()
        {
            var id = Client.CreateBroadcastSchedule(CreateBroadcastSchedule);
            Assert.AreEqual(BroadcastScheduleId, id);
        }
    }
}
