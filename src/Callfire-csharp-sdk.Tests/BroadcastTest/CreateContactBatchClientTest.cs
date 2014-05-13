using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class CreateContactBatchClientTest
    {
        protected IBroadcastClient Client;

        protected CfCreateContactBatch ExpectedCreateContactBatch;
        protected long BroadcastId;

        [Test]
        public void Test_CreateContactBatch()
        {
            var id = Client.CreateContactBatch(ExpectedCreateContactBatch);
            Assert.AreEqual(BroadcastId, id);
        }
    }
}
