using System;
using CallFire_csharp_sdk.API.Rest;
using CallFire_csharp_sdk.API.Soap;
using CallFire_csharp_sdk.Common.DataManagement;
using CallFire_csharp_sdk.Common.Resource;
using CallFire_csharp_sdk.Common.Result;
using CallFire_csharp_sdk.Common.Result.Mappers;
using NUnit.Framework;
using Rhino.Mocks;
using ServiceStack.Common.Web;
using ServiceStack.ServiceClient.Web;

namespace Callfire_csharp_sdk.Tests.SubscriptionTest.Rest
{
    [TestFixture]
    public class QuerySubscriptionsRestClientTest : QuerySubscriptionsClientTest
    {
        protected JsonServiceClient JsonServiceClientMock;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            JsonServiceClientMock = MockRepository.GenerateMock<JsonServiceClient>();
            Client = new RestSubscriptionClient(JsonServiceClientMock);

            Query = new CfQuery(100, 0);

            SubscriptionFilter = new CfSubscriptionSubscriptionFilter(1, 5, "fromNumber", "toNumber", true);
            Subscription = new CfSubscription(1, true, "endPoint", CfNotificationFormat.Soap,
                CfSubscriptionTriggerEvent.CampaignStarted, SubscriptionFilter);

            var subscriptions = new CfSubscription[1];
            subscriptions[0] = Subscription;
            SubscriptionQueryResult = new CfSubscriptionQueryResult(1, subscriptions);

            GenerateMock(SubscriptionQueryResult, Query);

            subscriptions[0] = null;
            var subscriptionQueryResult = new CfSubscriptionQueryResult(1, subscriptions);
            var query = new CfQuery(100, 1);
            GenerateMock(subscriptionQueryResult, query);
        }

        private void GenerateMock(CfSubscriptionQueryResult subscriptionQueryResult, CfQuery query)
        {
            JsonServiceClientMock
                .Stub(j => j.Send<SubscriptionQueryResult>(Arg<string>.Is.Equal(HttpMethods.Get), Arg<string>.Is.Equal(String.Format("/subscription?MaxResults={0}&FirstResult={1}", query.MaxResults, query.FirstResult)),
                    Arg<object>.Is.Null))
                .Return(SubscriptionQueryResultMapper.ToSoapSubscriptionQueryResult(subscriptionQueryResult));
        }
    }
}
