
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class ControlBroadcastClientTests
    {
        protected IBroadcastClient Client;

        protected long Id;
        protected string RequestId;
        protected int MaxActive;

        [Test]
        public void Test_ControlBroadcast()
        {
            var controlBroadcast = new CfControlBroadcast(Id, RequestId, CfBroadcastCommand.Start, MaxActive);
            Client.ControlBroadcast(controlBroadcast);
        }
    }
}
