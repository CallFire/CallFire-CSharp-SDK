using CallFire_csharp_sdk.API;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class DeleteBroadcastScheduleClientTest
    {
        protected IBroadcastClient Client;
        protected long BroadcastScheduleId;

        [Test]
        public void Test_DeleteBroadcastSchedule()
        {
            Client.DeleteBroadcastSchedule(BroadcastScheduleId);
        }
    }
}
