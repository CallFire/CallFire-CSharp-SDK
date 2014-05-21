using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class CallfireBroadcastClientTest
    {
        protected IBroadcastClient Client;
        protected CfBroadcast ExpectedBroadcast;
        protected CfQueryBroadcasts CfQueryBroadcasts;
        
        [Test]
        public void Test_CreateBroadcast()
        {
            var id = Client.CreateBroadcast(ExpectedBroadcast);
            Assert.AreEqual(ExpectedBroadcast.Id, id);
        }

        [Test]
        public void Test_QueryBroadcast()
        {
            var queryResult = Client.QueryBroadcasts(CfQueryBroadcasts);
            Assert.NotNull(queryResult);
            Assert.AreEqual(1, queryResult.TotalResults);
        }

        [Test]
        public void Test_GetBroadcast()
        {
            Client.GetBroadcast(1);
        }
    }
}
