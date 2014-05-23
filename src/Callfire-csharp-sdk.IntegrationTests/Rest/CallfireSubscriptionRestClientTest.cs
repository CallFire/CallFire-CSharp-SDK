using CallFire_csharp_sdk.API.Rest;
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
            //App Login: 66cb7463de00
            //Password: bc16e515e85cd3e1

            Client = new RestSubscriptionClient("66cb7463de00", "bc16e515e85cd3e1");

            var subscriptionFilter = new CfSubscriptionSubscriptionFilter(1, 5, "fromNumber", "toNumber", true);
            CfSubscription = new CfSubscription(1, true, "endPoint", CfNotificationFormat.Soap,
                CfSubscriptionTriggerEvent.CampaignStarted, subscriptionFilter);
            CfSubscriptionRequest = new CfSubscriptionRequest("requestId", CfSubscription);
        }
    }
}
