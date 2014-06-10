using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.Soap
{
    [TestFixture]
    public class CallfireTextSoapClientTest : CallfireTextClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Client = new SoapTextClient(MockClient.User(), MockClient.Password());

            var localTimeZoneRestriction = new CfLocalTimeZoneRestriction(DateTime.Now, DateTime.Now);
            CfResult[] result = { CfResult.Received };
            CfRetryPhoneType[] phoneTypes = { CfRetryPhoneType.FirstNumber };
            var broadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, result, phoneTypes);
            var textBroadcastConfig = new CfTextBroadcastConfig(1, DateTime.Now, "14252163710", localTimeZoneRestriction, broadcastConfigRestryConfig, "Test", CfBigMessageStrategy.DoNotSend);

            var toNumber = new CfToNumber[1];
            toNumber[0] = new CfToNumber("Data", null, "14252163710");

            SendText = new CfSendText(String.Empty, CfBroadcastType.Text, "broadcastSoap", toNumber, false, textBroadcastConfig, 1875873001, true);

            CfActionQuery = new CfActionQuery(100, 0, 1838228001, 1092170001, new[] { CfActionState.Ready }, null, false, new DateTime(2014, 1, 1),
                new DateTime(2014, 12, 1), null, null, null);

            QueryAutoReplies = new CfQueryAutoReplies(100, 0, null);
        }
    }
}
