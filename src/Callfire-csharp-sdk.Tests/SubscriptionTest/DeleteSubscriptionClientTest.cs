using CallFire_csharp_sdk.API;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest
{
    [TestFixture]
    public abstract class DeleteSubscriptionClientTest
    {
        protected ISubscriptionClient Client;
        protected long SubscriptionId;

        [Test]
        public void DeleteSubscription()
        {
            Client.DeleteSubscription(SubscriptionId);
        }
    }
}
