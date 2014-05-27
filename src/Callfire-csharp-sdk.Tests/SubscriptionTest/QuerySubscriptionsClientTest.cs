using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest
{
    [TestFixture]
    public abstract class QuerySubscriptionsClientTest
    {
        protected ISubscriptionClient Client;
        protected CfSubscription Subscription;
        protected CfSubscriptionSubscriptionFilter SubscriptionFilter;
        protected CfQuery Query;
        protected CfSubscriptionQueryResult SubscriptionQueryResult;
        
        [Test]
        public void QuerySubscriptions()
        {
            var subscriptions = Client.QuerySubscriptions(Query);
            Assert.IsNotNull(subscriptions);
        }

        [Test]
        public void QuerySubscriptions_Properties()
        {
            var subscriptionQueryResult = Client.QuerySubscriptions(Query);
            Assert.IsNotNull(subscriptionQueryResult);

            Assert.AreEqual(SubscriptionQueryResult.TotalResults, subscriptionQueryResult.TotalResults);
            var subscriptions = subscriptionQueryResult.Subscription;
            Assert.IsNotNull(subscriptions);
        }

        [Test]
        public void QuerySubscriptions_SubscriptionItem_Properties()
        {
            Query = new CfQuery(100, 0);
            var subscriptionQueryResult = Client.QuerySubscriptions(Query);
            Assert.IsNotNull(subscriptionQueryResult);

            var subscriptions = subscriptionQueryResult.Subscription;
            Assert.IsNotNull(subscriptions);

            var subscription = subscriptions[0];
            Assert.AreEqual(Subscription.Endpoint, subscription.Endpoint);
            Assert.AreEqual(Subscription.NotificationFormat, subscription.NotificationFormat);
            Assert.AreEqual(Subscription.TriggerEvent, subscription.TriggerEvent);
            Assert.IsNotNull(subscription.SubscriptionFilter);
        }
    }
}
