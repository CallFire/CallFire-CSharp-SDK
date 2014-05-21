using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource.Mappers;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest.Rest
{
    [TestFixture]
    public class GetSubscriptionRestClientTest : GetSubscriptionClientTest
    {
        protected XmlServiceClient XmlServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            XmlServiceClientMock = MockRepository.GenerateMock<XmlServiceClient>();
            Client = new RestSubscriptionClient(XmlServiceClientMock);

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
            XmlServiceClientMock
                .Stub(j => j.Send<Subscription>(Arg<string>.Is.Equal(HttpMethods.Get), Arg<string>.Is.Equal(String.Format("/subscription/{0}", SubscriptionId)),
                    Arg<object>.Is.Null))
                .Return(SubscriptionMapper.ToSoapSubscription(subscription));
        }
    }
}
