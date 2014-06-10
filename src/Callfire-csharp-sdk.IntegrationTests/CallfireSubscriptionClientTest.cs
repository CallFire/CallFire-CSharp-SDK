using System.Linq;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.IntegrationTests
{
    [TestFixture]
    public abstract class CallfireSubscriptionClientTest
    {
        protected ISubscriptionClient Client;

        protected CfSubscriptionRequest CfSubscriptionRequest;
        protected CfSubscription CfSubscription;
        protected CfQuery QuerySubscription;
        protected CfSubscriptionRequest CfUpdateSubscription;

        [Test]
        public void Test_CreateSuscription()
        {
            var id = Client.CreateSubscription(CfSubscriptionRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_GetSuscription()
        {
            var subscription = Client.GetSubscription(139597001);
            Assert.NotNull(subscription);
        }

        [Test]
        public void Test_QuerySuscription()
        {
            var subscriptionQueryResult = Client.QuerySubscriptions(QuerySubscription);
            Assert.NotNull(subscriptionQueryResult);
            Assert.IsNotNull(subscriptionQueryResult.Subscription);
            Assert.IsTrue(subscriptionQueryResult.Subscription.Any(s => s.NotificationFormat.Equals(CfNotificationFormat.Email)));
        }

        [Test]
        [Ignore]
        public void Test_DeleteSuscription()
        {
            var id = Client.CreateSubscription(CfSubscriptionRequest);
            Client.DeleteSubscription(id);
        }

        [Test]
        [Ignore]
        public void Test_UpdateSuscription()
        {
            Client.UpdateSubscription(CfUpdateSubscription);
        }
    }
}
