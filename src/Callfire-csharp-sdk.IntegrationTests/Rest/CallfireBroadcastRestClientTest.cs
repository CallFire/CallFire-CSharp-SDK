using System;
using CallFire_csharp_sdk.API.Rest.Clients;
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
            CfRetryPhoneType[] phoneTypes = { CfRetryPhoneType.FirstNumber };
            var broadcastConfigRestryConfig = new CfBroadcastConfigRetryConfig(1000, 2, result, phoneTypes);
            var expectedTextBroadcastConfig = new CfTextBroadcastConfig(1, DateTime.Now, string.Empty, localTimeZoneRestriction, 
                broadcastConfigRestryConfig, "Test", CfBigMessageStrategy.DoNotSend);
            ExpectedBroadcast = new CfBroadcast(14898, "broadcastRest", CfBroadcastStatus.Running, DateTime.Now, 
                CfBroadcastType.Text, expectedTextBroadcastConfig);

            CfBroadcastType[] broadcastType = { CfBroadcastType.Text };
            CfQueryBroadcasts = new CfQueryBroadcasts(100, 0, broadcastType, null, null);

            QueryContactBatches = new CfQueryBroadcastData(100, 0, 1838228001);
            ControlContactBatches = new CfControlContactBatch(1092170001, "ContactBatchRest", true);
            GetBroadcastStats = new CfGetBroadcastStats(1838228001, new DateTime(2014, 01, 01), new DateTime(2014, 12, 01));

            var textBroadcastConfig = new CfTextBroadcastConfig(1, DateTime.Now, "67076", null, null,
                "Test Message Rest", CfBigMessageStrategy.DoNotSend);
            var broadcast = new CfBroadcast(1838228001, "broadcastUpdated_Rest", CfBroadcastStatus.Running, DateTime.Now,
                CfBroadcastType.Text, textBroadcastConfig);
            UpdateBroadcast = new CfBroadcastRequest("", broadcast);

            ControlBroadcast = new CfControlBroadcast(0, null, CfBroadcastCommand.Archive, null);

            const long id = 188717001;
            object[] contactList = { id };
            CreateContactBatch = new CfCreateContactBatch(null, 1907978001, "ContactBatchSoap", contactList, false);
        }
    }
}
