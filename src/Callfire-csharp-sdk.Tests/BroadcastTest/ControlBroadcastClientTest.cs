using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class ControlBroadcastClientTest
    {
        protected IBroadcastClient Client;

        protected CfControlBroadcast ExpectedControlBroadcast;
        
        [Test]
        public void Test_ControlBroadcast()
        {
            var controlBroadcast = new CfControlBroadcast(ExpectedControlBroadcast.Id, ExpectedControlBroadcast.RequestId, CfBroadcastCommand.Start, ExpectedControlBroadcast.MaxActive);
            Client.ControlBroadcast(controlBroadcast);
        }
    }
}
