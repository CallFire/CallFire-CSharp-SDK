using CallFire_csharp_sdk.API;
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

        [Test]
        public void Test_QueryBroadcast()
        {
            MaxResult = 5;
            var cfQueryBroadcasts = new CfQueryBroadcasts(MaxResult, FirstResult, null, true, false, null);
            
            var cfBroadcastQueryResult = Client.QueryBroadcasts(cfQueryBroadcasts);
            Assert.IsNotNull(cfBroadcastQueryResult);
        }
    }
}
