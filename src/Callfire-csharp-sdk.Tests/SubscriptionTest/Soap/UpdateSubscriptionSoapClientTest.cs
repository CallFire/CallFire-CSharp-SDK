using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest.Soap
{
    [TestFixture]
    public class UpdateSubscriptionSoapClientTest : UpdateSubscriptionClientTest
    {
        protected ISubscriptionServicePortTypeClient SubscriptionServiceMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            SubscriptionServiceMock = MockRepository.GenerateStub<ISubscriptionServicePortTypeClient>();
            Client = new SoapSubscriptionClient(SubscriptionServiceMock);

            SubscriptionId = 1;
            SubscriptionFilter = new CfSubscriptionSubscriptionFilter(1, 5, "fromNumber", "toNumber", true);
            Subscription = new CfSubscription(SubscriptionId, true, "endPoint", CfNotificationFormat.Soap, CfSubscriptionTriggerEvent.CampaignStarted, SubscriptionFilter);
            SubscriptionRequest = new CfSubscriptionRequest("requestId", Subscription);

            var notificationFormat = EnumeratedMapper.ToSoapEnumerated<NotificationFormat>(Subscription.NotificationFormat.ToString());
            var triggerEvent = EnumeratedMapper.ToSoapEnumerated<SubscriptionTriggerEvent>(Subscription.TriggerEvent.ToString());
            SubscriptionServiceMock.Stub(b => b.UpdateSubscription(
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
                                                              x.Subscription.SubscriptionFilter.Inbound == SubscriptionFilter.Inbound)));
        }
    }
}
