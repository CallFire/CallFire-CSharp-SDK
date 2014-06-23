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
        protected string LabelName;


        //DeleteLabel

        [Test]
        public void Test_DeleteLabelComplete()
        {
            //Valid label
        }
        [Test]
        public void Test_DeleteLabelInvalid()
        {
            //InValid label
        }

        //QueryLabels
        [Test]
        public void Test_QueryLabelsAllResults()
        {
            //go to Try it out!

        }
        [Test]
        public void Test_QueryLabelsComplete()
        {

          
            //MaxResults 1000
            //FirstResult 0

        }

        //LabelBroadcast






        






        [Test]
        public void Test_CreateBroadcastLabel()
        {
            LabelClient.LabelBroadcast(BroadcastId,"New broadcastlabel");

            var result = LabelClient.QueryLabels(new CfQuery(10, 0));
            Assert.IsTrue(result.Labels.Any(l => l.Name == "New broadcastlabel"));
        }

        [Test]
        public void Test_DeleteLabel()
        {
            LabelClient.LabelBroadcast(BroadcastId, LabelName);
            LabelClient.DeleteLabel(LabelName);
            var result = LabelClient.QueryLabels(new CfQuery(10, 0));
            Assert.IsTrue(result.Labels.All(l => l.Name != LabelName));
        }

        [Test]
        public void Test_UnlabelBroadcast()
        {
            LabelClient.LabelBroadcast(BroadcastId, LabelName);
            LabelClient.UnlabelBroadcast(BroadcastId, LabelName);
        }
    }
}
