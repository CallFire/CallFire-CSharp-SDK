using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
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
            var broadcast = new CfBroadcast(ExpectedBroadcast.Id, ExpectedBroadcast.Name, CfBroadcastStatus.Running, ExpectedBroadcast.LastModified, CfBroadcastType.Text, null);
            var id = Client.CreateBroadcast(broadcast);

            Assert.AreEqual(ExpectedBroadcast.Id, id);
        }
    }
}
