using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Rest.Clients;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest.Rest
{
    [TestFixture]
    public class UpdateSubscriptionRestClientTest : UpdateSubscriptionClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestSubscriptionClient(HttpClientMock);

            SubscriptionId = 1;
            SubscriptionFilter = new CfSubscriptionSubscriptionFilter(1, 5, "fromNumber", "toNumber", true);
            Subscription = new CfSubscription(SubscriptionId, true, "endPoint", CfNotificationFormat.Soap,
                CfSubscriptionTriggerEvent.CampaignStarted, SubscriptionFilter);
            SubscriptionRequest = new CfSubscriptionRequest("requestId", Subscription);

            var notificationFormat = EnumeratedMapper.ToSoapEnumerated<NotificationFormat>(Subscription.NotificationFormat.ToString());
            var triggerEvent = EnumeratedMapper.ToSoapEnumerated<SubscriptionTriggerEvent>(Subscription.TriggerEvent.ToString());
            
            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/subscription/{0}", SubscriptionId)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Put),
                    Arg<SubscriptionRequest>.Matches(x => x.RequestId == SubscriptionRequest.RequestId &&
                                                          x.Subscription.id == Subscription.Id &&
                                                          x.Subscription.Enabled == Subscription.Enabled &&
                                                          x.Subscription.Endpoint == Subscription.Endpoint &&
                                                          x.Subscription.NotificationFormat == notificationFormat &&
                                                          x.Subscription.TriggerEvent == triggerEvent &&
                                                          x.Subscription.SubscriptionFilter.BroadcastId == SubscriptionFilter.BroadcastId &&
                                                          x.Subscription.SubscriptionFilter.BatchId == SubscriptionFilter.BatchId &&
                                                          x.Subscription.SubscriptionFilter.FromNumber == SubscriptionFilter.FromNumber &&
                                                          x.Subscription.SubscriptionFilter.ToNumber == SubscriptionFilter.ToNumber &&
                                                          x.Subscription.SubscriptionFilter.Inbound == SubscriptionFilter.Inbound)))
                .Return(string.Empty);
        }
    }
}