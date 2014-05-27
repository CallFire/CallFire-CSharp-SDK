using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.Rest
{
    [TestFixture]
    public class CallfireSubscriptionRestClientTest : CallfireSubscriptionClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Client = new RestSubscriptionClient(MockClient.User(), MockClient.Password());

            var subscriptionFilter = new CfSubscriptionSubscriptionFilter(1, 5, "fromNumber", "toNumber", true);
            CfSubscription = new CfSubscription(1, true, "endPoint", CfNotificationFormat.Soap,
                CfSubscriptionTriggerEvent.CampaignStarted, subscriptionFilter);
            CfSubscriptionRequest = new CfSubscriptionRequest("requestId", CfSubscription);
        }
    }
}
