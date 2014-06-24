using System;
using System.Linq;
using System.Net;
using System.ServiceModel;
using CallFire_csharp_sdk.API;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Soap;
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

        protected const string VerifyFromNumber = "+15712655344";
        protected const string VerifyShortCode = "67076";
        protected const long ExistingSubscriptionId = 148447001;

        public void AssertClientException<TRest, TSoap>(TestDelegate test)
            where TRest : Exception
            where TSoap : Exception
        {
            if (Client.GetType() == typeof(RestSubscriptionClient))
            {
                Assert.Throws<TRest>(test);
            }
            else
            {
                Assert.Throws<TSoap>(test);
            }
        }

        /// <summary>
        /// CreateSubscription
        /// </summary>
        [Test]
        public void Test_CreateSuscription()
        {
            var id = Client.CreateSubscription(CfSubscriptionRequest);
            Assert.IsNotNull(id);
        }
        
        [Test]
        public void Test_CreateSubscriptionEndpointID()
        {
            var subscriptionRequest = new CfSubscriptionRequest
            {
                Subscription = new CfSubscription
                {
                    Endpoint = "mbaliero@callfire.com",
                    TriggerEvent = CfSubscriptionTriggerEvent.CampaignStarted
                }
            };
            var id = Client.CreateSubscription(subscriptionRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateSubscriptionCompleteTrue()
        {
            var subscriptionRequest = new CfSubscriptionRequest
            {
                Subscription = new CfSubscription
                {
                    Endpoint = "mbaliero@callfire.com",
                    TriggerEvent = CfSubscriptionTriggerEvent.InboundCallFinished,
                    NotificationFormat = CfNotificationFormat.Xml,
                    Enabled = true,
                    SubscriptionFilter = new CfSubscriptionSubscriptionFilter
                    {
                        FromNumber = VerifyShortCode,
                        Inbound = true,
                        BroadcastId = 1903388001,
                        ToNumber = VerifyFromNumber
                    }
                }
            };
            var id = Client.CreateSubscription(subscriptionRequest);
            Assert.IsNotNull(id);
        }

        [Test]
        public void Test_CreateSubscriptionCompleteFalse()
        {
            var subscriptionRequest = new CfSubscriptionRequest
            {
                Subscription = new CfSubscription
                {
                    Endpoint = "mbaliero@callfire.com",
                    TriggerEvent = CfSubscriptionTriggerEvent.OutboundTextFinished,
                    NotificationFormat = CfNotificationFormat.Email,
                    Enabled = false,
                    SubscriptionFilter = new CfSubscriptionSubscriptionFilter
                    {
                        FromNumber = VerifyShortCode,
                        Inbound = false,
                        BroadcastId = 1903388001,
                        ToNumber = VerifyFromNumber
                    }
                }
            };
            var id = Client.CreateSubscription(subscriptionRequest);
            Assert.IsNotNull(id);
        }

        /// <summary>
        /// QuerySubscriptions
        /// </summary>
        [Test]
        public void Test_QuerySuscription()
        {
            var subscriptionQueryResult = Client.QuerySubscriptions(QuerySubscription);
            Assert.NotNull(subscriptionQueryResult);
            Assert.IsNotNull(subscriptionQueryResult.Subscription);
            Assert.IsTrue(subscriptionQueryResult.Subscription.Any(s => s.NotificationFormat.Equals(CfNotificationFormat.Email)));
        }
        
        [Test]
        public void Test_querySubsctiptionsAllResults()
        {
            var subscriptionQueryResult = Client.QuerySubscriptions(new CfQuery());
            Assert.IsNotNull(subscriptionQueryResult);
        }

        [Test]
        public void Test_querySubsctiptionsSpecialResults()
        {
            var query = new CfQuery
            {
                FirstResult = 1,
                MaxResults = 20
            };
            var subscriptionQueryResult = Client.QuerySubscriptions(query);
            Assert.IsNotNull(subscriptionQueryResult);
        }

        /// <summary>
        /// GetSubscriptions
        /// </summary>
        [Test]
        public void Test_GetSuscription()
        {
            var subscription = Client.GetSubscription(139597001);
            Assert.NotNull(subscription);
        }
        
        [Test]
        public void Test_GetSubscriptionsValid()
        {
            var subscription = Client.GetSubscription(ExistingSubscriptionId);
            Assert.IsNotNull(subscription);
        }

        [Test]
        public void Test_GetSubscriptionsInValidID()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.GetSubscription(150415000));
        }

        /// <summary>
        /// UpdateSubscription
        /// </summary>
        [Test]
        [Ignore]
        public void Test_UpdateSuscription()
        {
            Client.UpdateSubscription(CfUpdateSubscription);
        }
        
        [Test]
        public void Test_UpdateSubscriptionEmpty()
        {
            var subscriptionRequest = new CfSubscriptionRequest
            {
                Subscription = new CfSubscription()
            };
            AssertClientException<WebException, FaultException>(() => Client.UpdateSubscription(subscriptionRequest));
        }

        [Test]
        public void Test_UpdateSubscriptionTrue()
        {
            var subscriptionRequest = new CfSubscriptionRequest
            {
                Subscription = new CfSubscription
                {
                    Endpoint = "mbaliero@callfire.com",
                    TriggerEvent = CfSubscriptionTriggerEvent.OutboundTextFinished,
                    NotificationFormat = CfNotificationFormat.Email,
                    Enabled = false,
                    SubscriptionFilter = new CfSubscriptionSubscriptionFilter
                    {
                        FromNumber = VerifyShortCode,
                        Inbound = false,
                        BroadcastId = 1903388001,
                        ToNumber = VerifyFromNumber
                    }
                }
            };
            var id = Client.CreateSubscription(subscriptionRequest);

            var updateSubscriptionRequest = new CfSubscriptionRequest
            {
                Subscription = new CfSubscription
                {
                    Id = id,
                    Enabled = true,
                    NotificationFormat = CfNotificationFormat.Xml,
                    TriggerEvent = CfSubscriptionTriggerEvent.CampaignStopped,
                    SubscriptionFilter = new CfSubscriptionSubscriptionFilter
                    {
                        FromNumber = VerifyFromNumber,
                        Inbound = true
                    }
                }
            };
            Client.UpdateSubscription(updateSubscriptionRequest);

            var subscription = Client.GetSubscription(id);
            Assert.AreEqual(true, subscription.Enabled);
            Assert.AreEqual(CfNotificationFormat.Xml, subscription.NotificationFormat);
            Assert.AreEqual(CfSubscriptionTriggerEvent.CampaignStopped, subscription.TriggerEvent);
            Assert.AreEqual(VerifyFromNumber, subscription.SubscriptionFilter.FromNumber);
        }

        [Test]
        public void Test_UpdateSubscriptionFalse()
        {
            var subscriptionRequest = new CfSubscriptionRequest
            {
                Subscription = new CfSubscription
                {
                    Endpoint = "mbaliero@callfire.com",
                    TriggerEvent = CfSubscriptionTriggerEvent.OutboundTextFinished,
                    NotificationFormat = CfNotificationFormat.Email,
                    Enabled = true,
                    SubscriptionFilter = new CfSubscriptionSubscriptionFilter
                    {
                        FromNumber = VerifyShortCode,
                        Inbound = true,
                        BroadcastId = 1903388001,
                        ToNumber = VerifyFromNumber
                    }
                }
            };
            var id = Client.CreateSubscription(subscriptionRequest);

            var updateSubscriptionRequest = new CfSubscriptionRequest
            {
                Subscription = new CfSubscription
                {
                    Id = id,
                    Enabled = false,
                    NotificationFormat = CfNotificationFormat.Soap,
                    TriggerEvent = CfSubscriptionTriggerEvent.CampaignStarted,
                    SubscriptionFilter = new CfSubscriptionSubscriptionFilter
                    {
                        FromNumber = VerifyFromNumber,
                        Inbound = false
                    }
                }
            };
            Client.UpdateSubscription(updateSubscriptionRequest);

            var subscription = Client.GetSubscription(id);
            Assert.AreEqual(false, subscription.Enabled);
            Assert.AreEqual(CfNotificationFormat.Soap, subscription.NotificationFormat);
            Assert.AreEqual(CfSubscriptionTriggerEvent.CampaignStarted, subscription.TriggerEvent);
            Assert.AreEqual(VerifyFromNumber, subscription.SubscriptionFilter.FromNumber);
        }

        /// <summary>
        /// DeleteSubscription
        /// </summary>
        [Test]
        [Ignore]
        public void Test_DeleteSuscription()
        {
            var id = Client.CreateSubscription(CfSubscriptionRequest);
            Client.DeleteSubscription(id);
        }
        
        [Test]
        public void Test_DeleteSubscriptionIdNull()
        {
            AssertClientException<WebException, FaultException<ServiceFaultInfo>>(() => Client.DeleteSubscription(4867));
        }

        [Test]
        public void Test_DeleteSubscriptionComplete()
        {
            var subscriptionRequest = new CfSubscriptionRequest
            {
                Subscription = new CfSubscription
                {
                    Endpoint = "mbaliero@callfire.com",
                    TriggerEvent = CfSubscriptionTriggerEvent.OutboundTextFinished,
                    NotificationFormat = CfNotificationFormat.Email,
                    Enabled = true,
                }
            };
            var id = Client.CreateSubscription(subscriptionRequest);

            Client.DeleteSubscription(id);
        }
    }
}
