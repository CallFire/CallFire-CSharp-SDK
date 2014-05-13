using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class ControlContactBatchClientTest
    {
        protected IBroadcastClient Client;

        protected CfControlContactBatch ExpectedControlContactBatch;
        protected long ControlContactBatchId;

        [Test]
        public void Test_ControlContactBatch()
        {
            Client.ControlContactBatch(ExpectedControlContactBatch);
        }
    }
}
