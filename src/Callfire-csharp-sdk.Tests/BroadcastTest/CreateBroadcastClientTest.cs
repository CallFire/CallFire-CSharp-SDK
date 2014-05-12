using System;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class CreateBroadcastClientTest
    {
        protected IBroadcastClient Client;
        
        protected long BroadcastId;
        protected string BroadcastName;
        protected DateTime BroadcastLastModified;
        
        [Test]
        public void Test_CreateBroadcast()
        {
            var broadcast = new CfBroadcast(BroadcastId, BroadcastName, CfBroadcastStatus.Running, BroadcastLastModified, CfBroadcastType.Text, null);
            var id = Client.CreateBroadcast(broadcast);

            Assert.AreEqual(BroadcastId, id);
        }
    }
}
