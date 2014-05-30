using System.Linq;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
{
    [TestFixture]
    public abstract class CallfireLabelClientTest
    {
        protected ILabelClient LabelClient;
        protected IBroadcastClient BroadcastClient;
        protected long BroadcastId;
        
        [Test]
        public void Test_CreateBroadcastLabel()
        {
            LabelClient.LabelBroadcast(BroadcastId,"New broadcastlabel");

            var result = LabelClient.QueryLabels(new CfQuery(10, 0));
            Assert.IsTrue(result.Labels.Any(l => l.Name == "New broadcastlabel"));
        }
    }
}
