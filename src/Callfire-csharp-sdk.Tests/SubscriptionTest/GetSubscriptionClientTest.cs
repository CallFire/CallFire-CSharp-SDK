using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest
{
    [TestFixture]
    public abstract class GetSubscriptionClientTest
    {
        protected ISubscriptionClient Client;
        protected CfSubscription Subscription;
        protected CfSubscriptionSubscriptionFilter SubscriptionFilter;
        protected long SubscriptionId;

        [Test]
        public void GetSubscription()
        {
            SubscriptionId = 1;
            var subscription = Client.GetSubscription(SubscriptionId);
            Assert.IsNotNull(subscription);
        }

        [Test]
        public void GetSubscription_Properties()
        {
            SubscriptionId = 1;
            var subscription = Client.GetSubscription(SubscriptionId);
            Assert.IsNotNull(subscription);

            Assert.AreEqual(Subscription.Endpoint, subscription.Endpoint);
            Assert.AreEqual(Subscription.NotificationFormat, subscription.NotificationFormat);
            Assert.AreEqual(Subscription.TriggerEvent, subscription.TriggerEvent);
            Assert.IsNotNull(subscription.SubscriptionFilter);
        }

        [Test]
        public void GetSubscription_With_Null_SubscriptionFilter()
        {
            SubscriptionId = 2;
            var subscription = Client.GetSubscription(SubscriptionId);
            Assert.IsNotNull(subscription);

            var subscriptionFilter = subscription.SubscriptionFilter;
            Assert.IsNull(subscriptionFilter);
        }

        [Test]
        public void GetSubscription_SubscriptionFilter_Properties()
        {
            SubscriptionId = 1;
            var subscription = Client.GetSubscription(SubscriptionId);
            Assert.IsNotNull(subscription);

            var subscriptionFilter = subscription.SubscriptionFilter;
            Assert.IsNotNull(subscriptionFilter);
            Assert.AreEqual(SubscriptionFilter.FromNumber, subscriptionFilter.FromNumber);
            Assert.AreEqual(SubscriptionFilter.ToNumber, subscriptionFilter.ToNumber);
        }
    }
}