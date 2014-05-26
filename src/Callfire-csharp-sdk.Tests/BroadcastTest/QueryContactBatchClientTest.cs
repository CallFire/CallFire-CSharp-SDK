using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class QueryContactBatchClientTest
    {
        protected IBroadcastClient Client;

        protected CfQueryBroadcastData ExpectedQueryBroadcastData;
        protected CfContactBatchQueryResult ExpectedContactBatchQueryResult;
        protected CfContactBatch ExpectedContactBatch;

        [Test]
        public void Test_QueryContactBatch()
        {
            var cfContactBatchQueryResult = Client.QueryContactBatches(ExpectedQueryBroadcastData);
            Assert.IsNotNull(cfContactBatchQueryResult);
        }

        [Test]
        public void Test_QueryContactBatch_properties()
        {
            var cfContactBatchQueryResult = Client.QueryContactBatches(ExpectedQueryBroadcastData);
            Assert.IsNotNull(cfContactBatchQueryResult);

            var cfContactBatch = cfContactBatchQueryResult.ContactBatch[0];
            Assert.IsNotNull(cfContactBatch);
        }

        [Test]
        public void Test_QueryContactBatch_ContactBatch_properties()
        {
            var cfContactBatchQueryResult = Client.QueryContactBatches(ExpectedQueryBroadcastData);
            Assert.IsNotNull(cfContactBatchQueryResult);
            
            var cfContactBatch = cfContactBatchQueryResult.ContactBatch[0];
            Assert.IsNotNull(cfContactBatch);

            Assert.AreEqual(ExpectedContactBatch.Id, cfContactBatch.Id);
            Assert.AreEqual(ExpectedContactBatch.Name, cfContactBatch.Name);
            Assert.AreEqual(ExpectedContactBatch.Status, cfContactBatch.Status);
            Assert.AreEqual(ExpectedContactBatch.BroadcastId, cfContactBatch.BroadcastId);
            Assert.AreEqual(ExpectedContactBatch.Created, cfContactBatch.Created);
        }
    }
}
