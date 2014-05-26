using System;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest
{
    [TestFixture]
    public abstract class UpdateBroadcastClientTest
    {
        protected IBroadcastClient Client;

        protected long BroadcastId;
        protected string BroadcastName;

        [Test]
        public void Test_UpdateBroadcast()
        {
            var broadcast = new CfBroadcast(BroadcastId, BroadcastName, CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Text, null);
            var broadcastRequest = new CfBroadcastRequest("", broadcast);
            Client.UpdateBroadcast(broadcastRequest);
        }
    }
}
