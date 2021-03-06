﻿using System;
using CallFire_csharp_sdk.API;
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
            CallfireClient = new CallfireClient(MockClient.User(), MockClient.Password(), CallfireClients.Soap);
            Client = CallfireClient.Text;

            var localTimeZoneRestriction = new CfLocalTimeZoneRestriction(DateTime.Now, DateTime.Now);
            CfResult[] result = { CfResult.Received };
            CfRetryPhoneType[] phoneTypes = { CfRetryPhoneType.FirstNumber };
            var broadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, result, phoneTypes);
            var textBroadcastConfig = new CfTextBroadcastConfig(1, DateTime.Now, "14252163710", localTimeZoneRestriction, broadcastConfigRestryConfig, "Test", CfBigMessageStrategy.DoNotSend);

            var toNumber = new CfToNumber[1];
            toNumber[0] = new CfToNumber("Data", null, "14252163710");

            SendText = new CfSendText(String.Empty, CfBroadcastType.Text, "broadcastSoap", toNumber, false, new string[] { "Test label" }, textBroadcastConfig, 1875873001, true);
            SendText = new CfSendText(String.Empty, CfBroadcastType.Text, "broadcastSoap", toNumber, false, textBroadcastConfig, 1875873001, true);

            CfActionQuery = new CfActionQuery(100, 0, 1838228001, 1092170001, new[] { CfActionState.Ready }, null, false, new DateTime(2014, 1, 1),
                new DateTime(2014, 12, 1), null, null, null);

            QueryAutoReplies = new CfQueryAutoReplies(100, 0, null);
        }

        [Test]
        public void Test_SendTextLabels()
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
                Labels = new string[] { "Test Label 1", "Test Label 2" }
            };
            var id = Client.SendText(sendText);
            Assert.IsNotNull(id);
        }
    }
}
