using System;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.Rest
{
    [TestFixture]
    public class CallfireTextRestClientTest : CallfireTextClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Client = new RestTextClient(MockClient.User(), MockClient.Password());

            var localTimeZoneRestriction = new CfLocalTimeZoneRestriction(DateTime.Now, DateTime.Now);
            CfResult[] result = { CfResult.Received };
            CfRetryPhoneType[] phoneTypes = { CfRetryPhoneType.FirstNumber };
            var broadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, result, phoneTypes);
            var textBroadcastConfig = new CfTextBroadcastConfig(1, DateTime.Now, "14252163710", localTimeZoneRestriction, broadcastConfigRestryConfig, "Test", CfBigMessageStrategy.DoNotSend);

            var toNumber = new [] { new CfToNumber("Data", null, "14252163710") };
            var labels = new string[] { "Test_Label_1", "Test_Label_2" };
            SendText = new CfSendText(String.Empty, CfBroadcastType.Text, "broadcastSoap", toNumber, false, labels, textBroadcastConfig, 1875873001, true);

            CfActionQuery = new CfActionQuery(100, 0, 1838228001, 1092170001, new[] { CfActionState.Ready }, null , false, new DateTime(2014, 1, 1),
                new DateTime(2014, 12, 1), null, null, null);

            QueryAutoReplies = new CfQueryAutoReplies(100, 0, null);
        }

        [Test]
        public void Test_SendTextLabelsRest()
        {
            CfToNumber[] toNumberList = { new CfToNumber { Value = VerifyFromNumber, ClientData = "Client1" } };
            var sendText = new CfSendText
            {
                ToNumber = toNumberList,
                UseDefaultBroadcast = true,
                Type = CfBroadcastType.Text,
                TextBroadcastConfig = new CfTextBroadcastConfig
                {
                    Message = "Test message",
                },
                Labels = new string[] { "Test_Label_1", "Test_Label_2" }
            };
            var id = Client.SendText(sendText);
            Assert.IsNotNull(id);
        }
    }
}
