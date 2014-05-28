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
    public class CreateSubscriptionRestClientTest : CreateSubscriptionClientTest
    {
        internal IHttpClient HttpClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            HttpClientMock = MockRepository.GenerateMock<IHttpClient>();
            Client = new RestSubscriptionClient(HttpClientMock);

            SubscriptionId = 14561;
            SubscriptionFilter = new CfSubscriptionSubscriptionFilter(1, 5, "fromNumber", "toNumber", true);
            Subscription = new CfSubscription(SubscriptionId, true, "endPoint", CfNotificationFormat.Soap,
                CfSubscriptionTriggerEvent.CampaignStarted, SubscriptionFilter);
            SubscriptionRequest = new CfSubscriptionRequest("requestId", Subscription);

            var notificationFormat = EnumeratedMapper.ToSoapEnumerated<NotificationFormat>(Subscription.NotificationFormat.ToString());
            var triggerEvent = EnumeratedMapper.ToSoapEnumerated<SubscriptionTriggerEvent>(Subscription.TriggerEvent.ToString());
            
            var response = string.Format("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>" +
                        "<r:ResourceReference xmlns=\"http://api.callfire.com/data\" xmlns:r=\"http://api.callfire.com/resource\">" +
                              "<r:Id>{0}</r:Id>" +
                              "<r:Location>https://www.callfire.com/api/1.1/rest/subscription/{0}</r:Location>" +
                        "</r:ResourceReference>", SubscriptionId);

            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal("/subscription"), Arg<HttpMethod>.Is.Equal(HttpMethod.Post), 
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
                            .Return(response);
        }
    }
}
