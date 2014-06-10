using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.Soap
{
    [TestFixture]
    public class CallfireLabelSoapClientTest : CallfireLabelClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            LabelClient = new SoapLabelClient(MockClient.User(), MockClient.Password());
            BroadcastClient = new SoapBroadcastClient(MockClient.User(), MockClient.Password());

            var localTimeZoneRestriction = new CfLocalTimeZoneRestriction(DateTime.Now, DateTime.Now);
            CfResult[] result = { CfResult.Received };
            CfRetryPhoneType[] phoneTypes = { CfRetryPhoneType.FirstNumber };
            var broadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, result, phoneTypes);
            var expectedTextBroadcastConfig = new CfTextBroadcastConfig(1, DateTime.Now, null, localTimeZoneRestriction, broadcastConfigRestryConfig, "Test", CfBigMessageStrategy.DoNotSend);
            var expectedBroadcast = new CfBroadcast(14898, "broadcastSoap", CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Text, expectedTextBroadcastConfig);
            var broadcastRequest = new CfBroadcastRequest("", expectedBroadcast);

            BroadcastId = BroadcastClient.CreateBroadcast(broadcastRequest);

            LabelName = "New SoapLabel";
        }
    }
}

