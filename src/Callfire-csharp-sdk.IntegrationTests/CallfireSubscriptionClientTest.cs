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

        [Test]
        public void Test_CreateSuscription()
        {
            var id = Client.CreateSubscription(CfSubscriptionRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_GetSuscription()
        {
            var subscription = Client.GetSubscription(140553001);
            Assert.NotNull(subscription);
        }
    }
}
