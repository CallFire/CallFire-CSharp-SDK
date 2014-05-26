using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.Rest
{
    [TestFixture]
    public class CallfireBroadcastRestClientTest : CallfireBroadcastClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Client = new RestBroadcastClient(MockClient.User(), MockClient.Password());
            
            var localTimeZoneRestriction = new CfLocalTimeZoneRestriction(DateTime.Now, DateTime.Now);
            CfResult[] result = { CfResult.Received };
            CfRetryPhoneType[] phoneTypes = { CfRetryPhoneType.First_Number };
            var broadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, result, phoneTypes);
            var expectedTextBroadcastConfig = new CfTextBroadcastConfig(1, DateTime.Now, string.Empty, localTimeZoneRestriction, broadcastConfigRestryConfig, "Test", CfBigMessageStrategy.DoNotSend);
            ExpectedBroadcast = new CfBroadcast(14898, "broadcastRest", CfBroadcastStatus.Running, DateTime.Now, CfBroadcastType.Text, expectedTextBroadcastConfig);

            CfBroadcastType[] broadcastType = { CfBroadcastType.Text };
            CfQueryBroadcasts = new CfQueryBroadcasts(100, 0, broadcastType, null, null);

        }
    }
}
