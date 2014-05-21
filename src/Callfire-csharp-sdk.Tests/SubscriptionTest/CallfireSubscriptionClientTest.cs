using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using NUnit.Framework;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest
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
            Assert.AreEqual(CfSubscription.Id, id);
        }

        [Test]
        public void Test_GetSuscription()
        {
            var subscription = Client.GetSubscription(1);
            Assert.NotNull(subscription);
        }
    }
}
