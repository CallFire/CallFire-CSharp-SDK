using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class CreateBroadcastClientTest
    {
        protected IBroadcastClient Client;

        protected CfBroadcast ExpectedBroadcast;
        
        [Test]
        public void Test_CreateBroadcast()
        {
            var broadcast = new CfBroadcast(ExpectedBroadcast.Id, ExpectedBroadcast.Name, ExpectedBroadcast.Status, ExpectedBroadcast.LastModified, ExpectedBroadcast.Type, ExpectedBroadcast.Item);
            var broadcastRequest = new CfBroadcastRequest("", broadcast);

            var id = Client.CreateBroadcast(broadcastRequest);
            Assert.AreEqual(ExpectedBroadcast.Id, id);
        }
    }
}
