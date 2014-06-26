using System;
using System.Net;
using System.ServiceModel;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
{
    [TestFixture]
    public abstract class CallfireLabelClientTest
    {
        protected ILabelClient Client;
        protected IBroadcastClient BroadcastClient;
        protected long BroadcastId;
        protected string LabelName;
        protected CfBroadcast Broadcast;

        protected const string VerifyShortCode = "67076";

        protected const string ExistingNumber = "13107742289";

        public void AssertClientException<TRest, TSoap>(TestDelegate test)
            where TRest : Exception
            where TSoap : Exception
        {
            if (Client.GetType() == typeof(RestLabelClient))
            {
                Assert.Throws<TRest>(test);
            }
            else
            {
                Assert.Throws<TSoap>(test);
            }
        }

        /// <summary>
        /// DeleteLabel
        /// </summary>
        [Test]
        public void Test_DeleteLabelComplete()
        {
            var broadcastRequest = new CfBroadcastRequest(string.Empty, Broadcast);
            var id = BroadcastClient.CreateBroadcast(broadcastRequest);

            Client.LabelBroadcast(id, "LABEL");
            Client.DeleteLabel("LABEL");
        }

        [Test]
        public void Test_DeleteLabelInvalid()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.DeleteLabel("WRONGLABEL"));
        }

        /// <summary>
        /// QueryLabels
        /// </summary>
        [Test]
        public void Test_QueryLabelsAllResults()
        {
            var labelQueryResult = Client.QueryLabels(new CfQuery());
            Assert.IsNotNull(labelQueryResult);
        }

        [Test]
        public void Test_QueryLabelsComplete()
        {
            var query = new CfQuery
            {
                FirstResult = 0,
                MaxResults = 1000
            };
            var labelQueryResult = Client.QueryLabels(query);
            Assert.IsNotNull(labelQueryResult);
        }

        /// <summary>
        /// LabelBroadcast
        /// </summary>
        
        [Test]
        public void Test_LabelBroadcastMandatoryComplete()
        {
            var broadcastRequest = new CfBroadcastRequest(string.Empty, Broadcast);
            var id = BroadcastClient.CreateBroadcast(broadcastRequest);

            Client.LabelBroadcast(id, "NEWLABEL");
        }

        [Test]
        public void Test_LabelBroadcastWrongData()
        {
            AssertClientException<WebException, FaultException>(() => Client.LabelBroadcast(48616816, null));
        }

        [Test]
        public void Test_LabelBroadcastNotExistId()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.LabelBroadcast(48616816, "NEWLABEL"));
        }

        /// <summary>
        /// UnlabelBroadcast
        /// </summary>
        [Test]
        public void Test_UnlabelBroadcastNotExistId()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.UnlabelBroadcast(6879561468, "NEWUNLABEL"));
        }

        [Test]
        public void Test_UnlabelBroadcastMandatoryComplete()
        {
            var broadcastRequest = new CfBroadcastRequest(string.Empty, Broadcast);
            var id = BroadcastClient.CreateBroadcast(broadcastRequest);

            Client.LabelBroadcast(id, "NEWUNLABEL");
            Client.UnlabelBroadcast(id, "NEWUNLABEL");
        }

        [Test]
        public void Test_UnlabelBroadcastWrongData()
        {
            var broadcastRequest = new CfBroadcastRequest(string.Empty, Broadcast);
            var id = BroadcastClient.CreateBroadcast(broadcastRequest);

            Client.LabelBroadcast(id, "NEWUNLABEL");
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.UnlabelBroadcast(id, "WRONGLABEL"));
        }

        /// <summary>
        /// LabelNumber
        /// </summary>
        [Test]
        public void Test_LabelNumberNotExistNumber()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.LabelNumber("4894513216", "WRONGLABEL"));
        }

        [Test]
        public void Test_LabelNumberMandatoryComplete()
        {
            Client.LabelNumber(ExistingNumber, "NUMBERLABEL");
        }

        [Test]
        public void Test_LabelNumberWrongData()
        {
            AssertClientException<WebException, FaultException>(() => Client.LabelNumber(ExistingNumber, null));
        }

        /// <summary>
        /// UnlabelNumber
        /// </summary>
        [Test]
        public void Test_UnlabelNumberNotExistNumber()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.UnlabelNumber("4894516516", "WRONGLABEL"));
        }

        [Test]
        public void Test_UnlabelNumberMandatoryComplete()
        {
            Client.LabelNumber(ExistingNumber, "UNLABEL");
            Client.UnlabelNumber(ExistingNumber, "UNLABEL");
        }

        [Test]
        public void Test_UnlabelNumberWrongData()
        {
            Client.LabelNumber(ExistingNumber, "WRONGDATALABEL");
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.UnlabelNumber(ExistingNumber, "WRONGDATA"));
        }
    }
}
