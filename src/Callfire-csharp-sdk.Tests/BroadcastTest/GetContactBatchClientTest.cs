using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class GetContactBatchClientTest
    {
        protected IBroadcastClient Client;

        protected CfContactBatch ExpectedContactBatch;
        protected long ContactBatchId;

        [Test]
        public void Test_GetContactBatch()
        {
            ContactBatchId = 1;
            var contactBatch = Client.GetContactBatch(ContactBatchId);

            Assert.IsNotNull(contactBatch);
        }

        [Test]
        public void Test_GetContactBatch_Properties()
        {
            ContactBatchId = 1;
            var contactBatch = Client.GetContactBatch(ContactBatchId);

            Assert.IsNotNull(contactBatch);
            Assert.AreEqual(ExpectedContactBatch.Id, contactBatch.Id);
            Assert.AreEqual(ExpectedContactBatch.Name, contactBatch.Name);
            Assert.AreEqual(ExpectedContactBatch.Status, contactBatch.Status);
            Assert.AreEqual(ExpectedContactBatch.BroadcastId, contactBatch.BroadcastId);
            Assert.AreEqual(ExpectedContactBatch.Created, contactBatch.Created);
            Assert.AreEqual(ExpectedContactBatch.Size, contactBatch.Size);
            Assert.AreEqual(ExpectedContactBatch.Remaining, contactBatch.Remaining);
        }
    }
}
