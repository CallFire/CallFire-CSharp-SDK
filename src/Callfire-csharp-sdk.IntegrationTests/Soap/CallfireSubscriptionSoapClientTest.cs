using System.Configuration;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests.Soap
{
    [TestFixture]
    public class CallfireSubscriptionSoapClientTest : CallfireSubscriptionClientTest
    {
        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            Client = new SoapSubscriptionClient(MockClient.User(), MockClient.Password());

            var user = ConfigurationManager.AppSettings.Get("AppLogin");
            var pass = ConfigurationManager.AppSettings.Get("Password");
            Client = new SoapSubscriptionClient(user, pass);

            var subscriptionFilter = new CfSubscriptionSubscriptionFilter(1, 5, "fromNumber", "toNumber", true);
            CfSubscription = new CfSubscription(1, true, "endPoint", CfNotificationFormat.Soap, CfSubscriptionTriggerEvent.UndefinedEvent, subscriptionFilter);
            CfSubscriptionRequest = new CfSubscriptionRequest("", CfSubscription);
        }
    }
}
