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
        public void Test_LabelBroadcastMandatoryComplete()
        {
            //

        }
        [Test]
        public void Test_LabelBroadcastWrongData()
        {
            //id valid
            //name diferent

        }
        [Test]
        public void Test_LabelBroadcastNotExistId()
        {
            //id not exist
            //

        }

        //UnlabelBroadcast
        [Test]
        public void Test_UnlabelBroadcastNotExistId()
        {
            //id not exist
            //

        }
        [Test]
        public void Test_UnlabelBroadcastMandatoryComplete()
        {
            //

        }
        [Test]
        public void Test_UnlabelBroadcastWrongData()
        {
            //id valid
            //name diferent

        }

        //LabelNumber
        [Test]
        public void Test_LabelNumberNotExistNumber()
        {
            //number not exist
            //

        }
        [Test]
        public void Test_LabelNumberMandatoryComplete()
        {
            //

        }
        [Test]
        public void Test_LabelNumberWrongData()
        {
            //number valid
            //labelname diferent

        }

        //UnlabelNumber
        [Test]
        public void Test_UnlabelNumberNotExistNumber()
        {
            //number not exist
            //

        }
        [Test]
        public void Test_UnlabelNumberMandatoryComplete()
        {
            //

        }
        [Test]
        public void Test_UnlabelNumberWrongData()
        {
            //number valid
            //labelname diferent

        }















        






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
