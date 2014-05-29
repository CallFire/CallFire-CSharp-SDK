﻿//using System;
//using CallFire_csharp_sdk.API.Soap;
//using CallFire_csharp_sdk.Common.DataManagement;
//using CallFire_csharp_sdk.Common.Resource;
//using NUnit.Framework;

//namespace Callfire_csharp_sdk.IntegrationTests.Soap
//{
//    [TestFixture]
//    class CallfireCallSoapClientTest : CallfireCallClientTest
//    {
//        [TestFixtureSetUp]
//        public void FixtureSetup()
//        {
//            Client = new SoapCallClient(MockClient.User(), MockClient.Password());

//            var localTimeZoneRestriction = new CfLocalTimeZoneRestriction(DateTime.Now, DateTime.Now);
//            CfResult[] result = { CfResult.Received };
//            CfRetryPhoneType[] phoneTypes = { CfRetryPhoneType.FirstNumber };
//            var broadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, result, phoneTypes);
//            var ivrBroadcastConfig = new CfIvrBroadcastConfig(1, DateTime.Now, "+14252163710", localTimeZoneRestriction, broadcastConfigRestryConfig, 
//                "<dialplan><play type=\"tts\">Congratulations! You have successfully configured a CallFire I V R.</play></dialplan>");

//            var toNumber = new CfToNumber[1];
//            toNumber[0] = new CfToNumber("Data", null, "+14252163710");

//            SendCall = new CfSendCall(String.Empty, CfBroadcastType.Ivr, "broadcastSoap", toNumber, false, ivrBroadcastConfig);

//            ActionQuery = new CfActionQuery(100, 0, 1838228001, 1092170001, null, null, false, DateTime.Parse("01/01/2014"),
//                DateTime.Parse("31/12/2014"), "+14252163710", "+14252163710", string.Empty);
//        }
//    }
//}