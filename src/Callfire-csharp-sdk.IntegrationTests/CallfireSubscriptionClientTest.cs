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

        /// <summary>
        /// //////////////Subscription////////
        /// </summary>
        /// 
        //CreateSubscription
        [Test]
        public void Test_CreateSubscriptionEndpointID()
        {
            //
            //Endpoint= valid

        }
        [Test]
        public void Test_CreateSubscriptionCompleteTrue()
        {
            //
            //Enabled= TRue
            //NotificationFormat= XML
            //TriggerEvent = INBOULND_CALL_FINISHED
            //Inbound = true

        }
        [Test]
        public void Test_CreateSubscriptionCompleteFalse()
        {
            //
            //Enabled= False
            //NotificationFormat= Email
            //TriggerEvent = OUTBOUND_TEXT_FINISHED 
            //Inbound = False

        }

        //querySubsctiptions
        [Test]
        public void Test_querySubsctiptionsAllResults()
        {
            //all empty


        }
        public void Test_querySubsctiptionsSpecialResults()
        {
            //MaxResults= 20
            //FirstResult= 1

        }
        //getsubscriptions
        [Test]
        public void Test_getsubscriptionsValid()
        {
            //ID valid
        }
        public void Test_getsubscriptionsInValidID()
        {
            //ID INvalid
        }

        //UpdateSubscription
        [Test]
        public void Test_UpdateSubscriptionEmpty()
        {
            //Subscription[id]= null
        }

        [Test]
        public void Test_UpdateSubscriptionTrue()
        {
            //Enabled=true
            //NotificationFormat=Xml
            //TriggerEvent= wherever
            //Inbound=True
            //Subscription[id]= valid
        }
        public void Test_UpdateSubscriptionFalse()
        {
            //Enabled=False
            //NotificationFormat=Soup
            //TriggerEvent= wherever
            //Inbound=false
            //Subscription[id]= valid
        }

        //DeleteSubscription

        [Test]
        public void Test_DeleteSubscriptionIdNull()
        {
            //
        }
        [Test]
        public void Test_DeleteSubscriptionComplete()
        {
            //valid id
        }






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
