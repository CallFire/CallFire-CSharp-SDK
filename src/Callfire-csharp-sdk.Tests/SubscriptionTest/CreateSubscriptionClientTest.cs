using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest
{
    [TestFixture]
    public abstract class CreateSubscriptionClientTest
    {
        protected ISubscriptionClient Client;

        protected long SubscriptionId;
        protected CfSubscriptionRequest SubscriptionRequest;
        protected CfSubscription Subscription;
        protected CfSubscriptionSubscriptionFilter SubscriptionFilter;

        [Test]
        public void CreateSubscription()
        {
            var id = Client.CreateSubscription(SubscriptionRequest);
            Assert.AreEqual(SubscriptionId, id);
        }
    }
}
