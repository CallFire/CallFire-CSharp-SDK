using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
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
            var broadcastRequest = new CfBroadcastRequest("", ExpectedBroadcast);
            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_QueryBroadcast()
        {
            var queryResult = Client.QueryBroadcasts(CfQueryBroadcasts);
            Assert.NotNull(queryResult);
            Assert.NotNull(queryResult.Broadcast);
        }

        [Test]
        public void Test_GetBroadcast()
        {
            var broadcast = Client.GetBroadcast(1838228001);
            Assert.IsNotNull(broadcast);
        }
    }
}
