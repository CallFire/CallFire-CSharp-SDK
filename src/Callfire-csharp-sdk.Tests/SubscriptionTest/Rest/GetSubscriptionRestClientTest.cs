using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.Common;
using CallFire_csharp_sdk.Common.DataManagement;
using NUnit.Framework;
using Rhino.Mocks;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest.Rest
{
    [TestFixture]
    public class GetSubscriptionRestClientTest : GetSubscriptionClientTest
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
            GenerateMock(Subscription);

            SubscriptionId = 2;
            var subscription = new CfSubscription(SubscriptionId, true, "endPoint", CfNotificationFormat.Soap,
                CfSubscriptionTriggerEvent.CampaignStarted, null);
            GenerateMock(subscription);
        }

        private void GenerateMock(CfSubscription subscription)
        {
            HttpClientMock
                .Stub(j => j.Send(Arg<string>.Is.Equal(String.Format("/subscription/{0}", SubscriptionId)),
                    Arg<HttpMethod>.Is.Equal(HttpMethod.Get),
                    Arg<object>.Is.Null))
                .Return("");//SubscriptionMapper.ToSoapSubscription(subscription));
        }
    }
}
