using System;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class QueryBroadcastClientTest
    {
        protected IBroadcastClient Client;

        protected long MaxResult;
        protected long FirstResult;
        protected string LabelName;
        protected long BroadcastId;
        protected string BroadcastName;
        protected DateTime BroadcastLastModified;

        [Test]
        public void Test_QueryBroadcast()
        {
            var cfQueryBroadcasts = new CfQueryBroadcasts(MaxResult, FirstResult, CfBroadcastType.Ivr, true, false, LabelName);
            
            var cfBroadcastQueryResult = Client.QueryBroadcasts(cfQueryBroadcasts);
            Assert.IsNotNull(cfBroadcastQueryResult);
        }

        [Test]
        public void Test_Broadcast()
        {
            var cfQueryBroadcasts = new CfQueryBroadcasts(MaxResult, FirstResult, CfBroadcastType.Ivr, true, false, LabelName);

            var cfBroadcastQueryResult = Client.QueryBroadcasts(cfQueryBroadcasts);
            Assert.IsNotNull(cfBroadcastQueryResult);

            var broadcast = cfBroadcastQueryResult.Broadcast[0];
            Assert.IsNotNull(broadcast);
            Assert.AreEqual(BroadcastId, broadcast.Id);
            Assert.AreEqual(BroadcastName, broadcast.Name);
            Assert.AreEqual(CfBroadcastStatus.Running, broadcast.Status);
            Assert.AreEqual(BroadcastLastModified, broadcast.LastModified);
            Assert.AreEqual(CfBroadcastType.Ivr, broadcast.Type);
            Assert.IsNull(broadcast.Item);
        }
    }
}
