using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.BroadcastTest.Rest
{
    [TestFixture]
    public class CallfireBroadcastRestClientTest : CallfireBroadcastClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            //App Login: 66cb7463de00
            //Password: bc16e515e85cd3e1

            Client = new RestBroadcastClient("66cb7463de00", "bc16e515e85cd3e1");
            
            var localTimeZoneRestriction = new CfLocalTimeZoneRestriction(DateTime.Now, DateTime.Now);
            CfResult[] result = { CfResult.Received };
            CfRetryPhoneType[] phoneTypes = { CfRetryPhoneType.First_Number };
            var broadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, result, phoneTypes);
            var expectedTextBroadcastConfig = new CfTextBroadcastConfig(1, DateTime.Now, "fromNumber", localTimeZoneRestriction, broadcastConfigRestryConfig, "Test", CfBigMessageStrategy.DoNotSend);
            ExpectedBroadcast = new CfBroadcast(14898, "broadcast", CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Text, expectedTextBroadcastConfig);

            CfBroadcastType[] broadcastType = { CfBroadcastType.Text };
            CfQueryBroadcasts = new CfQueryBroadcasts(100, 0, broadcastType, null, null);

        }
    }
}
