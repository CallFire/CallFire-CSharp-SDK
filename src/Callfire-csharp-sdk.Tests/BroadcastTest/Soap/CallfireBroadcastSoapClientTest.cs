using System;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Soap
{
    [TestFixture]
    public class CallfireBroadcastSoapClientTest : CallfireBroadcastClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            //App Login: 66cb7463de00
            //Password: bc16e515e85cd3e1

            Client = new SoapBroadcastClient("66cb7463de00", "bc16e515e85cd3e1");
            
            var localTimeZoneRestriction = new CfLocalTimeZoneRestriction(DateTime.Now, DateTime.Now);
            var broadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, "retryResult", "retryPhoneTypes");
            var expectedIvrBroadcastConfig = new CfIvrBroadcastConfig(1, DateTime.Now, "fromNumber", localTimeZoneRestriction, broadcastConfigRestryConfig, "dialplanXml");
            ExpectedBroadcast = new CfBroadcast(189, "broadcast", CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Ivr, expectedIvrBroadcastConfig);

            CfQueryBroadcasts = new CfQueryBroadcasts(100, 0, CfBroadcastType.Text, null, null);
        }
    }
}

